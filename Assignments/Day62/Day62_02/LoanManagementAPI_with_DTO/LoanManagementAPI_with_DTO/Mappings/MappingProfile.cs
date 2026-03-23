using AutoMapper;
using LoanManagementAPI_with_DTO.DTOs.CREATE;
using LoanManagementAPI_with_DTO.DTOs.GET;
using LoanManagementAPI_with_DTO.DTOs.UPDATE;
using LoanManagementAPI_with_DTO.Models;

namespace LoanManagementAPI_with_DTO.Mappings
{
    public class MappingProfile : Profile
    {
         public MappingProfile()
        {
            //From Client to Database
            CreateMap<AddLoan, Loan>();
            CreateMap<UpdateLoan, Loan>();

            //From Database to Client
            CreateMap<Loan, GetLoanDetails>();

            //if you want to support both directions (Create/update)
            //CreateMap<AddLoan, Loan>().ReverseMap(); // its a 2 way
            //communication like data can be sent from here to DB and data
            //can come from DB to DTO
        }
    }
}
