using System;

namespace Codific.Exceptions
{
    public class NotEnoughWeightCapacityForItemException : InvalidOperationException
    {
        public NotEnoughWeightCapacityForItemException() : base("Няма достатъчно място за предмета")
        {
        }
    }
}
