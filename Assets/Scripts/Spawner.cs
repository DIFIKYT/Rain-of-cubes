using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _y—ordinateSpawn;
    [SerializeField] private float _xMin—ordinateSpawn;
    [SerializeField] private float _xMax—ordinateSpawn;
    [SerializeField] private float _zMin—ordinateSpawn;
    [SerializeField] private float _zMax—ordinateSpawn;
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private List<Color> _colors;

    private void Spawn()
    {
        float xSpawn—ordinate = Random.Range(_xMin—ordinateSpawn, _xMax—ordinateSpawn);
        float zSpawn—ordinate = Random.Range(_zMin—ordinateSpawn, _zMax—ordinateSpawn);

        Vector3 position = new(xSpawn—ordinate, _y—ordinateSpawn, zSpawn—ordinate);

        Cube newCube = Instantiate(_cubePrefab, position, _cubePrefab.transform.rotation);
        newCube.LifeTimeOut += Destroy;
        newCube.ContactWithPlatform += ChoiceColor;
    }

    private void Destroy(Cube cube)
    {
        Destroy(cube.gameObject);
    }

    private void ChoiceColor(Cube cube)
    {
        cube.GetComponent<Renderer>().material.color = _colors[Random.Range(0, _colors.Count)];
    }
}