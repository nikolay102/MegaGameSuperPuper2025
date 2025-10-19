using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Game.Scripts
{
    public class CubeManager: MonoBehaviour
    {
        [SerializeField] private int cubesNumber = 1;
        [SerializeField] private Rigidbody target;
        private List<Rigidbody> cubes = new List<Rigidbody>();
        
        public List<Rigidbody> Cubes { get => cubes; set => cubes = value; }
        
        public void SpawnCubes()
        {
            var instance = Instantiate(target, new Vector3(Random.Range(33,53),3,Random.Range(6,29)), Quaternion.identity);
            cubes.Add(instance);
        }

        public void DestroyCubes()
        {
            if (cubes.Count > 0)
            {
               Destroy(cubes[0].gameObject); 
               cubes.Remove(cubes[0]);
            }
            else Debug.Log("Cubes are empty");
        }
        
        public void ThrowAll()
        {
            Cube[] allCubes = FindObjectsOfType<Cube>();
            
            foreach (Cube cube in allCubes)
            {
                cube.Jump();
                Debug.Log("ЛОХ");
            }
        }
    }
}