using UnityEngine;

public class BubbleSorter : MonoBehaviour
{
    [SerializeField] private Transform[] cubes;
    [SerializeField] private float offset;

    private void Start()
    {
        Sort();
        PlaceInLine();
    }

    private void Sort()
    {
        for (int i = 0; i < cubes.Length - 1; i++)
        {
            for (int j = 0; j < cubes.Length - i - 1; j++)
            {
                if (cubes[j].localScale.magnitude < cubes[j + 1].localScale.magnitude)
                {
                    (cubes[j], cubes[j + 1]) =  (cubes[j + 1], cubes[j]);
                }
            }
        }
    }

    private void PlaceInLine()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (i == 0)
                cubes[i].position = Vector3.zero;
            else
            {
                cubes[i].position = cubes[i - 1].position
                                    + new Vector3(
                                        cubes[i - 1].localScale.x / 2
                                        + offset
                                        + cubes[i].localScale.x / 2,
                                        0,
                                        0);
            }
        }
    }

}
