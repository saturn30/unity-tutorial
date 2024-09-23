using System.Linq;
using UnityEngine;

namespace Game.Utility
{
  public class RandomSelector
  {
    public T[] GetRandomElements<T>(T[] array, int count)
    {
      return array.OrderBy(x => Random.value).Take(count).ToArray();
    }
  }
}