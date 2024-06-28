using Moq;
using Project.DTOs;
using Project.Models;
using Project.Repositories.Abstraction;
using Project.Services;
using Xunit.Abstractions;

namespace MyProject.Tests;

public class CompanyClientsServiceTests
{
    private readonly ITestOutputHelper _output;
    private readonly CompanyClientsService _clientService;
    private readonly Mock<ICompanyClientsRepository> _mockRepository;

    public CompanyClientsServiceTests(ITestOutputHelper output)
    {
        _output = output;
        _mockRepository = new Mock<ICompanyClientsRepository>();
        _clientService = new CompanyClientsService(_mockRepository.Object);
    }

    [Fact]
    public async Task TestCompanyClientAdded()
    {
            
        // Arrange
        var clientDto = new AddCompanyClientDto()
        {
            Address = "Test Address",
            Email = "test@email.com",
            PhoneNumber = "123456789",
            CompanyName = "Test Company",
            KrsNumber = "123456789"
        };
        
        // Act
        var client = await _clientService.AddCompanyClient(clientDto);

        // Assert
        _mockRepository.Verify(
            repo => repo.AddAsync(
                It.Is<CompanyClient>(c => c == client)),
            Times.Once);
    }
    
    [Fact]
    public async Task TestCompanyClientPartialUpdates()
    {
        
        // Arrange
        var client = new CompanyClient()
        {
            IdClient = 1,
            Address = "Test Address",
            Email = "test@email.com",
            PhoneNumber = "123456789",
            CompanyName = "Test Company",
            KrsNumber = "123456789"
        };
        _mockRepository.Setup(x => x.FindAsync(1)).ReturnsAsync(client);
        
        // Act
        await _clientService.UpdateCompanyClient(1, new UpdateCompanyClientDto()
        {
            Address = "New Test Address",
            Email = "newTest@email.com"
        });
        
        
        // Assert
        _mockRepository.Verify(
            repo => repo.UpdateAsync(
                It.Is<CompanyClient>(
                    c => c.Address == "New Test Address" && c.Email == "newTest@email.com")
                ), Times.Once);
    }
    
    [Fact]
    public async Task TestCompanyClientFullUpdate()
    {
        
        // Arrange
        var client = new CompanyClient()
        {
            IdClient = 1,
            Address = "Test Address",
            Email = "test@email.com",
            PhoneNumber = "123456789",
            CompanyName = "Test Company",
            KrsNumber = "123456789"
        };
        _mockRepository.Setup(x => x.FindAsync(1)).ReturnsAsync(client);
        
        // Act
        await _clientService.UpdateCompanyClient(1, new UpdateCompanyClientDto()
        {
            Address = "New Test Address",
            Email = "newTest@email.com",
            PhoneNumber = "987654321",
            CompanyName = "New Test Company"
        });
        
        
        // Assert
        _mockRepository.Verify(
            repo => repo.UpdateAsync(
                It.Is<CompanyClient>(
                    c => 
                        c.Address == "New Test Address" && 
                        c.Email == "newTest@email.com" &&
                        c.PhoneNumber == "987654321" &&
                        c.CompanyName == "New Test Company")
            ), Times.Once);
    }
}