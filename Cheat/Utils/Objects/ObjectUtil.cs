using System.Runtime.CompilerServices;

namespace Priv9.Cheat.Utils.Objects
{
    internal static class ObjectUtil
    {
        public static object EnsureNotNull(object Checkable)
        {
            return Checkable ?? "";
        }

        public static bool IsInstance(object Checkable, object TypeIn)
        {
            return Checkable.GetType().IsInstanceOfType(TypeIn.GetType());
        }

        public static bool IsInstance(object Checkable, Type TypeIn)
        {
            return Checkable.GetType().IsInstanceOfType(TypeIn);
        }

        public static E Next<E>(E obj) where E : Enum
        {
            E[] Arr = (E[]) Enum.GetValues(obj.GetType());
            int j = Array.IndexOf(Arr, obj) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }
    }
}
