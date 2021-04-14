using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    void Start()
    {
        //InitializeArray();
        //InitializeList();
        //InitializeDictionary();
        //InitializeStack();
        InitializeQueue();
    }

    private void InitializeQueue()
    {
        Queue<BadGuy> badGuys = new Queue<BadGuy>();

        badGuys.Enqueue(new BadGuy("A", 10));
        badGuys.Enqueue(new BadGuy("B", 20));
        badGuys.Enqueue(new BadGuy("C", 30));
        badGuys.Enqueue(new BadGuy("D", 40));

        Debug.Log("Contagem da fila = " + badGuys.Count);

        while (badGuys.Count > 0)
        {
            BadGuy nextGuy = badGuys.Dequeue();
            Debug.Log(nextGuy);
            Debug.Log("Contagem da fila = " + badGuys.Count);
        }
    }

    private void InitializeStack()
    {
        Stack<BadGuy> badGuys = new Stack<BadGuy>();

        badGuys.Push(new BadGuy("A", 10));
        badGuys.Push(new BadGuy("B", 20));
        badGuys.Push(new BadGuy("C", 30));
        badGuys.Push(new BadGuy("D", 40));

        Debug.Log("Contagem da pilha = " + badGuys.Count);

        while(badGuys.Count > 0)
        {
            BadGuy nextGuy = badGuys.Pop();
            Debug.Log(nextGuy);
            Debug.Log("Contagem da pilha = " + badGuys.Count);
        }
    }

    private void InitializeDictionary()
    {
        Dictionary<string, BadGuy> badGuys = new Dictionary<string, BadGuy>();

        BadGuy bg1 = new BadGuy("Robotnik", 20);
        BadGuy bg2 = new BadGuy("A", 1000);
        BadGuy bg3 = new BadGuy("B", 300);

        Debug.Log(badGuys["A"]);

        if (badGuys.TryGetValue("Malévola", out BadGuy someGuy))
            Debug.Log(someGuy);
        else
            Debug.Log("Malévola não existe");

        foreach(var pair in badGuys)
        {
            Debug.LogFormat("[{0}] - {1}", pair.Key, pair.Value);
        }
    }

    private void InitializeList()
    {
        List<BadGuy> badGuys = new List<BadGuy>();
        badGuys.Add(new BadGuy("Robotnik", 20));
        badGuys.Add(new BadGuy("Thanos", 1000));
        badGuys.Add(new BadGuy("Rugal", 200));
        badGuys.Add(new BadGuy("Freeza", 80));

        badGuys.Insert(2, new BadGuy("Malévola", 333));
        badGuys.RemoveAt(badGuys.Count - 1);

        badGuys.Sort();

        Debug.Log("-- Foreach --");
        foreach (BadGuy badGuy in badGuys)
        {
            Debug.Log(badGuy);
        }
    }

    void InitializeArray()
    {
        BadGuy[] badGuys = new BadGuy[]
        {
            new BadGuy("Robotnik", 20),
            new BadGuy("Thanos", 1000),
            new BadGuy("Rugal", 200),
            new BadGuy("Freeza", 80),
        };

        Debug.Log("-- while --");
        int index = 0;
        while (index < badGuys.Length)
        {
            Debug.LogFormat("[{0}] {1}", index, badGuys[index]);
            index++;
        }

        Debug.Log("-- For --");
        for (int i = 0; i < badGuys.Length; i++)
        {
            Debug.LogFormat("[{0}] {1}", index, badGuys[i]);
        }

        Debug.Log("-- Foreach --");
        foreach (BadGuy badGuy in badGuys)
        {
            Debug.Log(badGuy);
        }
    }
}
