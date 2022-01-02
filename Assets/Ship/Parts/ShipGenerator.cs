using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField]
    private ShipPart superTurret;
    [SerializeField]
    private ShipPart superRam;
    [SerializeField]
    private ShipPart superHull;

    public Ship CreateShip(int powerLevel)
    {
        ShipPart[,] parts = new ShipPart[ShipConstants.SHIP_GRID_WIDTH, ShipConstants.SHIP_GRID_HEIGHT];

        var headX = ShipConstants.SHIP_GRID_WIDTH - 1;
        var headY = (int)(ShipConstants.SHIP_GRID_HEIGHT / 2);

        parts[headX, headY] = PickRandom(cockpits);

        bool isRammer = Random.Range(0, 2) == 1;

        if (isRammer)
        {
            parts[headX - 1, headY] = PickRandom(other);
            parts[headX - 2, headY] = PickRandom(engines);
            if (powerLevel > 1)
            {
                parts[headX, headY - 1] = PickRandom(rams);
                parts[headX - 1, headY] = PickRandom(other);
            }
            if (powerLevel > 5)
            {
                parts[headX, headY + 1] = PickRandom(rams);

                parts[headX - 1, headY + 1] = PickRandom(other);
                parts[headX - 1, headY] = PickRandom(other);

                parts[headX - 2, headY + 1] = PickRandom(engines);
                parts[headX - 2, headY - 1] = PickRandom(engines);
            }
            if (powerLevel > 7)
            {
                parts[headX, headY + 1] = PickRandom(rams);

                parts[headX - 2, headY - 1] = PickRandom(turrets);
                parts[headX - 2, headY + 1] = PickRandom(other);
                parts[headX - 2, headY] = PickRandom(other);

                parts[headX - 3, headY + 1] = PickRandom(engines);
                parts[headX - 3, headY - 1] = PickRandom(engines);
            }
            if (powerLevel > 9)
            {
                parts[headX - 4, headY + 1] = PickRandom(engines);
                parts[headX - 4, headY - 1] = PickRandom(rams);
                parts[headX - 4, headY] = PickRandom(engines);
                parts[headX - 3, headY] = PickRandom(rams);
            }
            if (powerLevel > 12)
            {
                parts[headX - 4, headY + 1] = superHull;
                parts[headX - 4, headY - 1] = superHull;
                parts[headX - 4, headY - 1] = superRam;
                parts[headX - 3, headY] = superRam;
            }
        }
        else
        {
            parts[headX - 1, headY] = PickRandom(turrets);
            parts[headX - 2, headY] = PickRandom(engines);
            if (powerLevel > 1)
            {
                parts[headX - 1, headY - 1] = PickRandom(turrets);
                parts[headX - 1, headY - 1] = PickRandom(other);
                parts[headX - 2, headY] = PickRandom(engines);
            }
            if (powerLevel > 5)
            {
                parts[headX - 1, headY + 1] = PickRandom(other);
                parts[headX - 1, headY] = PickRandom(other);

                parts[headX - 2, headY + 1] = PickRandom(turrets);
                parts[headX - 2, headY - 1] = PickRandom(engines);
            }
            if (powerLevel > 7)
            {
                parts[headX, headY + 1] = PickRandom(other);

                parts[headX - 2, headY - 1] = PickRandom(turrets);
                parts[headX - 2, headY + 1] = PickRandom(other);
                parts[headX - 2, headY] = PickRandom(other);

                parts[headX - 3, headY + 1] = PickRandom(turrets);
                parts[headX - 3, headY - 1] = PickRandom(turrets);
            }
            if (powerLevel > 9)
            {
                parts[headX - 4, headY + 1] = PickRandom(other);
                parts[headX - 4, headY - 1] = PickRandom(other);
                parts[headX - 4, headY] = PickRandom(turrets);
                parts[headX - 3, headY] = PickRandom(turrets);
            }
            if (powerLevel > 14)
            {
                parts[headX - 4, headY + 1] = superHull;
                parts[headX - 4, headY - 1] = superHull;
                parts[headX - 4, headY] = superTurret;
                parts[headX - 3, headY] = superTurret;
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


    public ShipPart GetRandomPart()
    {
        var allList = new List<ShipPart>();

        allList.AddRange(engines);
        allList.AddRange(turrets);
        allList.AddRange(rams);
        allList.AddRange(other);

        return PickRandom(allList);
    }

    public ShipPart GetRandomTurret()
    {
        return PickRandom(turrets);
    }

    public ShipPart GetRandomRam()
    {
        return PickRandom(rams);
    }

    public ShipPart GetRandomEngine()
    {
        return PickRandom(engines);
    }

    public static T PickRandom<T>(IList<T> source)
    {
        return source[Random.Range(0, source.Count)];
    }
}