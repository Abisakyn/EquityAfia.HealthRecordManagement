using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.DownloadLabResultsDTOs;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.DownloadLabResults
{
    public class DownloadLabResultsQueryHandler : IRequestHandler<DownloadLabResultsQuery, DownloadLabResultsResponse>
    {
        private readonly ILabResultsRepository _resultsRepository;

        public DownloadLabResultsQueryHandler(ILabResultsRepository resultsRepository)
        {
            _resultsRepository = resultsRepository;
        }

        public async Task<DownloadLabResultsResponse> Handle(DownloadLabResultsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var labResultsId = request.DownloadLabResultsDTO.LabResultsId;
                var labResults = await _resultsRepository.GetLabResultsByIdAsync(labResultsId);

                if (labResults == null)
                {
                    return null;
                }

                var testImage = ProcessFile(labResults.TestImage);
                var resultsImage = ProcessFile(labResults.ResultsImage);
                var diagnosis = labResults.Diagnosis;
                var tests = labResults.Test;
                var results = labResults.Results;
                var prescription = labResults.Prescriptions;

                var pdfFile = CreatePdf(testImage, resultsImage, tests, results, diagnosis, prescription);

                var response = new DownloadLabResultsResponse
                {
                    LabResultsId = labResults.LabResultsId,
                    PdfFile = pdfFile
                };
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while processing your request.", ex);
            }
        }

        private IFormFile ProcessFile(byte[] fileBytes)
        {
            try
            {
                return FormFileHelper.CreateFormFile(fileBytes);
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing file.", ex);
            }
        }

        private IFormFile CreatePdf(IFormFile testImage, IFormFile resultsImage, string tests, string results, string diagnosis, string prescription)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    var document = new Document();
                    var writer = PdfWriter.GetInstance(document, memoryStream);
                    document.Open();

                    // Add diagnosis, tests, results, prescription
                    AddTextToDocument(document, "Diagnosis", diagnosis);
                    AddTextToDocument(document, "Tests", tests);
                    AddTextToDocument(document, "Results", results);
                    AddTextToDocument(document, "Prescription", prescription);

                    // Add test image
                    AddImageToDocument(testImage, document);

                    // Add results image
                    AddImageToDocument(resultsImage, document);

                    document.Close();
                    writer.Close();

                    return new CustomFormFile(memoryStream.ToArray());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating PDF.", ex);
            }
        }

        private void AddImageToDocument(IFormFile imageFile, Document document)
        {
            if (imageFile == null)
                return;

            try
            {
                using (var imageStream = imageFile.OpenReadStream())
                {
                    var image = Image.GetInstance(imageStream);
                    image.ScaleToFit(PageSize.A4.Width - 20, PageSize.A4.Height - 20);
                    image.Alignment = Element.ALIGN_CENTER;
                    document.Add(image);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding image to document.", ex);
            }
        }

        private void AddTextToDocument(Document document, string title, string content)
        {
            if (string.IsNullOrEmpty(content))
                return;

            try
            {
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                var contentFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                // Add title
                var titleParagraph = new Paragraph(title, titleFont);
                document.Add(titleParagraph);

                // Add content
                var contentParagraph = new Paragraph(content, contentFont);
                document.Add(contentParagraph);

                // Add spacing
                document.Add(new Paragraph("\n"));
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding text to document.", ex);
            }
        }
    }
}
