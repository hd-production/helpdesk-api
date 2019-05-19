using AutoMapper;
using HdProduction.HelpDesk.Api.Models.TicketAttributes;
using HdProduction.HelpDesk.Api.Models.Tickets;
using HdProduction.HelpDesk.Api.Models.Users;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Api.Configuration
{
  public class AutoMapperConfig
  {
    public static IMapper Configure()
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMissingTypeMaps = true;
        cfg.AllowNullCollections = true;
        cfg.AllowNullDestinationValues = true;
        CreateMapping(cfg);
      });

      return config.CreateMapper();
    }

    private static void CreateMapping(IProfileExpression cfg)
    {
      cfg.CreateMap<Ticket, TicketResponseModel>();

      cfg.CreateMap<TicketAttribute, TicketAttributeResponse>();
      cfg.CreateMap<TicketAttributeRequest, TicketAttribute>();

      cfg.CreateMap<User, UserResponseModel>();
    }
  }
}