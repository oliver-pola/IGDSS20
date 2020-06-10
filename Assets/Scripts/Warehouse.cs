﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse
{
    // Enumeration of all available resource types. Can be addressed from other scripts by calling GameManager.ResourceTypes
    public enum ResourceTypes { None, Money, Wood, Planks, Fish, Wool, Clothes, Potato, Schnapps };

    // Holds a number of stored resources for every ResourceType
    private readonly Dictionary<ResourceTypes, float> _resources = new Dictionary<ResourceTypes, float>();

    public Warehouse()
    {
        PopulateResourceDictionary();
    }

    // Checks if there is at least one material for the queried resource type in the warehouse
    public bool HasResource(ResourceTypes resource)
    {
        return _resources[resource] >= 1;
    }

    // Checks if there is sufficient material for the queried resource type in the warehouse
    public bool HasResource(ResourceTypes resource, float amount)
    {
        return _resources[resource] >= amount;
    }

    // Adds resource
    public void AddResource(ResourceTypes resource, float amount)
    {
        _resources[resource] += amount;
    }

    // Removes resource
    public void RemoveResource(ResourceTypes resource, float amount)
    {
        _resources[resource] -= amount;
    }

    public override string ToString()
    {
        string s = "";
        foreach (var tuple in _resources)
            if (tuple.Key != ResourceTypes.None)
                s += tuple.Key + ": " + tuple.Value.ToString("000000") + " ";

        return s;
    }

    // Create an empty resource dictionary
    void PopulateResourceDictionary()
    {
        foreach (var type in (ResourceTypes[])Enum.GetValues(typeof(ResourceTypes)))
            _resources.Add(type, 0);
    }
}