using AutoMapper;
using RTF.Core.Models;
using RTF.CQS.ModelsFromUI.AdminResponseModels;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.CQS.Converters;

public class CqsMappingProfile : Profile
{
    public CqsMappingProfile()
    {			
        CreateMap<Event, EventFrame>();

        CreateMap<Event, ExtendedEventInfoFrame>()
            .ForMember(x => x.OrganizersNames, x =>
                x.MapFrom(y => y.Organizers.Select(z => $"{z.LastName} {z.FirstName}")));

        CreateMap<StoreProduct, ProductFrame>()
            .ForMember(x => x.NotAvailable, x =>
                x.MapFrom(y => y.TotalQuantity <= 0))
            .ForMember(x => x.StorageQuantity, x =>
                x.MapFrom(y => y.TotalQuantity));

        CreateMap<Order, AdminOrderFrame>()
            .ForMember(x => x.OrderId, x =>
                x.MapFrom(y => y.Id))
            .ForMember(x => x.StudentFullName, x =>
                x.MapFrom(y => $"{y.Student.LastName} {y.Student.FirstName}"))
            .ForMember(x => x.OrderProducts, x =>
                x.MapFrom(y => string.Join(", ", y.OrderProducts.Select(z => z.Product.Name))))
            .ForMember(x => x.TimeOfOrder, x =>
                x.MapFrom(y => y.PurchaseTime));
    }
}