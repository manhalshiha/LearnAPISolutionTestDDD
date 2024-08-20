using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public Entity(TId id)
        {
            if (!IsValid(id))
                throw new ArgumentException("Identifier is not a supported format ");
            Id = id;

        }
        public TId Id { get; }
        #region Inmplement Equality
        public override bool Equals(object? obj)
        {
            return Equals(obj as Entity<TId>);
        }
        public bool Equals(Entity<TId>? other)
        {
            return Id.GetHashCode == other.Id.GetHashCode;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public static bool operator ==(Entity<TId>lhs,Entity<TId>rhs)
        {
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Entity<TId>lhs,Entity<TId>rhs)
        {
            return !(lhs==rhs);
        }

        #endregion
        #region Private Members 
        private bool IsValid(TId id)
        {
            return id is int || id is long || id is Guid;
        }
        #endregion
    }
}
