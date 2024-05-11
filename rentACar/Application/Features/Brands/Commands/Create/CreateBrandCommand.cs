using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommand : IRequest<CreatedBrandResponse> //sen kullanıcının yapacağı isteksin, apiden böyle talep gelecek.Döndüreceği tipi de belirttik
    {
        public string NAME{ get; set; }

        //bu handle başka bir class olarak da yazılabilirdi, biz böyle yazdık
        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse> //mediatr'ın command'i handle etmesi için, her command'in bir handler'ı vardır 
        {
            public Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
                createdBrandResponse.NAME = request.NAME;
                createdBrandResponse.ID = new Guid();
                return null;
            }
        }
    }
}
