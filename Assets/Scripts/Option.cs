using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option<T> { 
    private T? value;
    public Option(T? value)
    {
        this.value = value;
    }

    public Option<T> Map(Func<T, T> func)
    {
        if (value == null)
        {
            return this;
        }

        return new Option<T>(func(value));
    }
}
