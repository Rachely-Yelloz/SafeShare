﻿using Microsoft.AspNetCore.Http;
using SafeShare.CORE.Entities;
using SafeShare.CORE.Repositories;
using SafeShare.CORE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeShare.SERVICE
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<bool> DeleteFileAsync(int fileId)
        {
            return await _fileRepository.DeleteFileAsync(fileId);
        }

        public async Task<FileToUpload> GetFileAsync(int fileId)
        {
            return await _fileRepository.GetFileAsync(fileId); 
        }

        public async Task<FileDownload> GetFileForDownloadAsync(int fileId)
        {
            return await _fileRepository.GetFileForDownloadAsync(fileId);
        }

        public async Task<bool> UpdateFileAsync(int fileId, FileToUpload file)
        {
            return await _fileRepository.UpdateFileAsync(fileId, file);
        }

        public async Task<bool> UpdateFileCountAsync(int fileId)
        {
            return await _fileRepository.UpdateFileCountAsync(fileId);

        }

        public async Task<bool> UploadFileAsync(IFormFile file, string fileName, string passwordHash)
        {
            return await _fileRepository.UploadFileAsync(file, fileName, passwordHash);
        }
    }
}
