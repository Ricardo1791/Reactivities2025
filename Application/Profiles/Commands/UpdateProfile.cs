using Application.Core;
using Application.Interfaces;
using Application.Profiles.Dtos;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Profiles.Commands
{
    public class UpdateProfile
    {

        public class Command: IRequest<Result<Unit>>
        {
            public required UpdateProfileDto Profile { get; set; }
            public required string Id { get; set; }
        }

        public class Handler(AppDbContext context, IUserAccessor userAccessor) : IRequestHandler<Command, Result<Unit>>
        {
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentUser = userAccessor.GetUserId();

                if (currentUser != request.Id) throw new Exception("Cannot update profile");

                var user = await context.Users.FindAsync(request.Id);

                if (user == null) throw new Exception("Profile not found");

                user.DisplayName = request.Profile.DisplayName;
                user.Bio = request.Profile.Bio;

                var result = await context.SaveChangesAsync() > 0;

                return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Problem updating profile", 400);
            }
        }
    }
}
