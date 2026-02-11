using Application.Profiles.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IPhotoService
    {
        Task<PhotoUploadResult?> UploadPhoto(IFormFile file);
        Task<string> DeletePhoto(string publicId);

    }
}
