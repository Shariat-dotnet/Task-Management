using AutoMapper;
using TaskManagement.Core.Extensions;
using TaskManagement.Core.Implements.Http;
using TaskManagement.Core.Interfaces.Database;
using TaskManagement.Core.Interfaces.Logging;
using MediatR;

namespace TaskManagement.Core.Infrastructure.Handlers
{
    public abstract class BaseHandler
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;        
        protected readonly IAppLogger Logger;
        protected readonly IMediator Mediator;

        protected readonly string UserId;
        protected readonly string Token;

        protected BaseHandler()
        {
            UnitOfWork = HttpAppService.GetRequestService<IUnitOfWork>();
            Mapper = HttpAppService.GetRequestService<IMapper>();
            Logger = HttpAppService.GetRequestService<IAppLogger>();
            Mediator = HttpAppService.GetRequestService<IMediator>();

        }
    }
}
