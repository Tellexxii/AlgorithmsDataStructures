﻿using System;
using System.Collections.Generic;
using System.Security;

namespace AlgorithmsDataStructures
{
    public class NativeCache<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public int[] hits;
        public int capacity;

        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
            capacity = 0;
        }

        public int HashFun(string key)
        {
            int index = Math.Abs(key.GetHashCode()) % size;
            return index;
        }

        public bool IsKey(string key)
        {
            int hash_index = this.HashFun(key);
            if (capacity != size)
            {
                return slots[hash_index] != null;
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    if (slots[(hash_index + i) % size].Equals(key))
                    {
                        return true;
                    }
                }

                return false;
            }
            

        }

        public void Put(string key, T value)
        {
            int index = this.HashFun(key);
            if (hits[index] == 0)
            {
                hits[index] = hits[index] + 1;
                slots[index] = key;
                values[index] = value;
                capacity++;
            }
            else
            {
                if (capacity == size)
                {
                    int lowerHitNum = hits[0];
                    int hit_index = 0;
                    for (int i = 1; i < size; i++)
                    {
                        if (hits[i] < lowerHitNum)
                        {
                            lowerHitNum = hits[i];
                            hit_index = i;
                        }
                    }

                    hits[hit_index] = 1;
                    slots[hit_index] = key;
                    values[hit_index] = value;
                }
                else
                {
                    hits[index] = hits[index] + 1;
                    slots[index] = key;
                    values[index] = value;
                }
            }
        }
        private bool IsKey(string key, out int index)
        {
            int hash_index = this.HashFun(key);
            if (capacity != size)
            {
                if (slots[hash_index] != null)
                {
                    index = hash_index;
                    return true;
                }
                else
                {
                    index = -1;
                    return false;
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    if (slots[(hash_index + i) % size].Equals(key))
                    {
                        index = (hash_index + i) % size;
                        return true;
                    }
                }

                index = -1;
                return false;
            }

        }
        public T Get(string key)
        {
            int hash_index;
            bool isKey = IsKey(key, out hash_index);
            return isKey ? values[hash_index] : default(T);
        }

    }
}