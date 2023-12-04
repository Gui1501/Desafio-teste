using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mttechne.Backend.Junior.Data.Model;
using Mttechne.Backend.Junior.Services.Model.Dtos;

namespace Mttechne.Backend.Junior.Services.Profiles
{
    public class ProdutoProfile: Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoDto>();
        }
    }
}
