using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using System;
using System.Data;
using System.Data.Common;

namespace HotelBooking.mapping
{
    public class DateTimeType : IUserType
    {
        public SqlType[] SqlTypes
        {
            get { return new SqlType[] { new StringSqlType() }; }
        }

        public Type ReturnedType => typeof(DateTime);

        public bool IsMutable => false;

        public object Assemble(object cached, object owner)
        {
            throw new NotImplementedException();
        }

        public object DeepCopy(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                // Perform a shallow copy by creating a new DateOnly instance with the same value
                return (DateTime)value;
            }
        }


        public object Disassemble(object value)
        {
            throw new NotImplementedException();
        }

        public new bool Equals(object x, object y)
        {
            if (x == null || y == null)
                return false;

            return x.Equals(y);
        }

        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var value = rs[names[0]];

            if (value == null || value == DBNull.Value)
            {
                return null;
            }
            else
            {
                // Convert the string value from the database to a DateOnly instance
                return DateTime.Parse((string)value);
            }
        }

        public object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            var value = rs[names[0]];

            if (value == null || value == DBNull.Value)
            {
                return null;
            }
            else
            {
                // Convert the string value from the database to a DateOnly instance
                return DateTime.Parse((string)value);
            }
        }



        public void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            var parameter = cmd.Parameters[index];

            if (value == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                // Convert the DateOnly instance to a string to store in the database
                parameter.Value = ((DateTime)value).ToString("yyyy-MM-dd hh:mm");
            }
        }


        public object Replace(object original, object target, object owner)
        {
            throw new NotImplementedException();
        }

    }

}
