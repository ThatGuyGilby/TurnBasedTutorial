using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private int baseValue = 1;
    [SerializeField] private List<int> modifiers = new List<int>();

    public Stat()
    {
        baseValue = 1;
        modifiers = new List<int>();
    }

    public int Value
    {
        get
        {
            int _totalValue = baseValue;

            foreach (int _value in modifiers)
            {
                _totalValue += _value;
            }

            return _totalValue;
        }
        private set
        {
            this.baseValue = value;
        }
    }

    public bool AddModifier(int _value)
    {
        if (_value == 0)
        {
            return false;
        }

        modifiers.Add(_value);
        return true;
    }

    public bool RemoveModifier(int _value)
    {
        if (_value == 0)
        {
            return false;
        }

        modifiers.Remove(_value);
        return true;
    }
}
