using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGenerator : MonoBehaviour
{
    [SerializeField]
    private List<ShipPart> cockpits;
    [SerializeField]
    private List<ShipPart> engines;
    [SerializeField]
    private List<ShipPart> turrets;
    [SerializeField]
    private List<ShipPart> rams;
    [SerializeField]
    private List<ShipPart> other;

    public Ship CreateShip(int powerLevel)
    {
        ShipPart[,] parts = new ShipPart[ShipConstants.SHIP_GRID_WIDTH, ShipConstants.SHIP_GRID_HEIGHT];

        var headX = ShipConstants.SHIP_GRID_WIDTH - 1;
        var headY = (int)(ShipConstants.SHIP_GRID_HEIGHT / 2);

        parts[headX, headY] = PickRandom(cockpits);

        bool isRammer = Random.Range(0, 2) == 1;

        if (isRammer)
        {
            if (powerLevel > 1)
            {
                parts[headX, headY - 1] = PickRandom(rams);
                parts[headX - 1, headY - 1] = PickRandom(other);
                parts[headX - 1, headY] = PickRandom(engines);
            }
            if (powerLevel > 3)
            {
                parts[headX, headY + 1] = PickRandom(rams);

                parts[headX - 1, headY + 1] = PickRandom(other);
                parts[headX - 1, headY] = PickRandom(other);

                parts[headX - 2, headY + 1] = PickRandom(engines);
                parts[headX - 2, headY - 1] = PickRandom(engines);
            }
        }
        else
        {
            if (powerLevel > 1)
            {
                parts[headX - 1, headY - 1] = PickRandom(turrets);
                parts[headX - 1, headY - 1] = PickRandom(other);
            }
            if (powerLevel > 3)
            {
                parts[headX, headY + 1] = PickRandom(rams);
                parts[headX - 1, headY + 1] = PickRandom(other);
                parts[headX - 1, headY] = PickRandom(other);
            }
        }

        for (int x = 0; x < ShipConstants.SHIP_GRID_WIDTH; x++)
        {
            for (int y = 0; y < ShipConstants.SHIP_GRID_HEIGHT; y++)
            {

            }
        }

        return new Ship(parts);
    }



    public static T PickRandom<T>(IList<T> source)
    {
        return source[Random.Range(0, source.Count)];
    }
}