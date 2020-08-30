using SchoolApp.Repositoreis;
using SchoolApp.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.WinClient.IoC
{
    public class TypeRegistery : StructureMap.Registry
    {
        public TypeRegistery()
        {
            For<IDbTools>().Use<SqlDbTools>();
        }
      
    }
}
