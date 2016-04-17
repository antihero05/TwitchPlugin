using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchPlugin.WebAPI
{

    #region Interfaces

    public interface INamespace
    {
        string BaseRequestURL
        {
            get;
        }

        List<NamespaceParameter> Parameters
        {
            get;
            set;
        }

        string RequestURL
        {
            get;
        }

        Type DataContract
        {
            get;
        }
    }

    public interface INamespaceParameters
    {
        List<NamespaceParameter> GetParameters();
    }

    #endregion Interfaces

    #region Classes

    public class NamespaceParameter
    {
        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }

    #endregion Classes

}
