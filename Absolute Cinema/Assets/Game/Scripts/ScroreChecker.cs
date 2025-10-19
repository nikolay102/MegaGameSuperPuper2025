using System;
using System.Collections.Generic;
using Game.Scripts;
using NUnit.Framework;
using UnityEngine;



public partial class ScroreChecker : MonoBehaviour
{
    [SerializeField]private bool alreadyShown = true;
    [SerializeField]private int scoreToVictory = 3;
    [SerializeField] private Rigidbody target;
    [SerializeField] private int cubesNumber = 1;
    [SerializeField] private CubeManager cubeManager;
    private int sumbob;
    public int Givn{get=>scoreToVictory; set=>scoreToVictory=value;}
    public int Sumboba{get=>sumbob; set=>sumbob=value;}
    
    public event Action<int> onSumbobChanged;
    public event Action<bool> onVictoryOrNot;
    
    private void OnEnable()
    {
        onSumbobChanged += Sumbob;
    }
    private void OnTriggerStay(Collider other) 
    {
        if(alreadyShown) return;

        var allQuietOnWesternFront = true;
        foreach (var cube in cubeManager.Cubes)
        {
            if (cube.linearVelocity.magnitude > 0.1f || cube.angularVelocity.magnitude > 0.1f)
            {
                allQuietOnWesternFront = false;
                break;
            }
        }

        if (allQuietOnWesternFront)
        {
            sumbob = 0;
                    foreach (var cube in cubeManager.Cubes)
                    {
                        {
                            Resultr result = cube.GetComponent<Cube>().result;
                            if (target.linearVelocity.magnitude < 0.1f && target.angularVelocity.magnitude < 0.1f)
                            {
                                Debug.Log((int)result);
                                sumbob+=(int)result;
                                onSumbobChanged?.Invoke(sumbob);
                            }
                           
                        }
                    }
                    alreadyShown = true;
                    Debug.Log($"сумбоб={sumbob}");
                    if (sumbob >= scoreToVictory)
                    {
                        onVictoryOrNot?.Invoke(true);
                        Debug.Log("ЛЭДЖЭНД");
                    }
                    else
                    {
                        onVictoryOrNot?.Invoke(false);
                        Debug.Log("ЛОх");
                    }
        }
        
    }
    
    private void Sumbob(int summa)
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var cube = other.GetComponentInParent<Cube>();
        cube.result = ShowResult(other.gameObject.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        alreadyShown = false;
    }

    private Resultr ShowResult(string tag)
    {
        switch (tag)
        {
            case "One": return Resultr.One;
            case "Two": return  Resultr.Two;
            case "Three": return  Resultr.Three;
            case "Four": return  Resultr.Four;
            case "Five": return  Resultr.Five;
            case "Six": return  Resultr.Six;
            default: return  Resultr.One;
        }
    }
}
