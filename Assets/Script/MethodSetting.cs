using UnityEngine;

public static class MethodSetting
{
    public static T GetItem<T>(string name, T[] arr) where T : Object
    {
        foreach (T item in arr)
            if (item.name == name)
                return item;

        return null;
    }
}
