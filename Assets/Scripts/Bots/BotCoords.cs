using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCoords : MonoBehaviour
{
    //Стандартная высота спавна (пока статичная, так как все спавнятся на плейне)
    [SerializeField] private float y;

    //Сюда передаётся объект (или объекты, в будущем), на которых ботам можно спавниться
    [SerializeField] private MeshRenderer PlaneBounds;

    private Vector3 CoordVector;
    private Vector3 BotWantedCoords;

    //Формирование валидных координатов. Вызывает метод для генерации координат, пока не получит такие, где никого нет в пределах квадрата со стороной 2
    //По идее должно исключить появление ботов в стенах, но чёт как-то не всегда работает...
    public Vector3 GetBotCoordinates()
    {
        BotWantedCoords = GenerateCoordinates();
        while (Physics.BoxCast(BotWantedCoords, new Vector3(2, 2, 2), new Vector3(2, 2, 2), Quaternion.Euler(0, 0, 0), 2))
        {
            BotWantedCoords = GenerateCoordinates();
        }
        return BotWantedCoords;

    }

    //Генерация координатов
    private Vector3 GenerateCoordinates()
    {
        return CoordVector = new Vector3(Random.Range(PlaneBounds.bounds.min.x + 1, PlaneBounds.bounds.max.x - 1), y, Random.Range(PlaneBounds.bounds.min.z + 1, PlaneBounds.bounds.max.z - 1));
    }
}
