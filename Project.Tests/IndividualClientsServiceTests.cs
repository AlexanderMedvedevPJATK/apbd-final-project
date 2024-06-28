using Moq;
using Project.DTOs;
using Project.Exceptions;
using Project.Models;
using Project.Repositories.Abstraction;
using Project.Services;
using Xunit.Abstractions;

namespace MyProject.Tests;

public class IndividualClientsServiceTests
{
    private readonly ITestOutputHelper _output;
    private readonly IndividualClientsService _clientService;
    private readonly Mock<IIndividualClientsRepository> _mockRepository;

    public IndividualClientsServiceTests(ITestOutputHelper output)
    {
        _output = output;
        _mockRepository = new Mock<IIndividualClientsRepository>();
        _clientService = new IndividualClientsService(_mockRepository.Object);
    }

    [Fact]
    public async Task TestIndividualClientAdded()
    {
            
        // Arrange
        var clientDto = new AddIndividualClientDto()
        {
            Address = "Test Address",
            Email = "test@email.com",
            PhoneNumber = "123456789",
            FirstName = "Test First Name",
            LastName = "Test Last Name",
            Pesel = "12345678901"
        };
        
        // Act
        var client = await _clientService.AddIndividualClient(clientDto);

        // Assert
        _mockRepository.Verify(
            repo => repo.AddAsync(
                It.Is<IndividualClient>(c => c == client)),
            Times.Once);
    }
    
    [Fact]
    public async Task TestIndividualClientPartialUpdates()
    {
        
        // Arrange
        var client = new IndividualClient()
        {
            IdClient = 1,
            Address = "Test Address",
            Email = "test@email.com",
            PhoneNumber = "123456789",
            FirstName = "Test First Name",
            LastName = "Test Last Name",
            Pesel = "12345678901"
        };
        _mockRepository.Setup(x => x.FindAsync(1)).ReturnsAsync(client);
        
        // Act
        await _clientService.UpdateIndividualClient(1, new UpdateIndividualClientDto()
        {
            Address = "New Test Address",
            Email = "newTest@email.com"
        });
        
        
        // Assert
        _mockRepository.Verify(
            repo => repo.UpdateAsync(
                It.Is<IndividualClient>(
                    c => c.Address == "New Test Address" && c.Email == "newTest@email.com")
                ), Times.Once);
    }
    
    [Fact]
    public async Task TestCompanyClientFullUpdate()
    {
        
        // Arrange
        var client = new IndividualClient()
        {
            IdClient = 1,
            Address = "Test Address",
            Email = "test@email.com",
            PhoneNumber = "123456789",
            FirstName = "Test First Name",
            LastName = "Test Last Name",
            Pesel = "12345678901"
        };
        _mockRepository.Setup(x => x.FindAsync(1)).ReturnsAsync(client);
        
        // Act
        await _clientService.UpdateIndividualClient(1, new UpdateIndividualClientDto()
        {
            Address = "New Test Address",
            Email = "newTest@email.com",
            PhoneNumber = "987654321",
            FirstName = "New Test First Name",
            LastName = "New Test Last Name"
        });
        
        
        // Assert
        _mockRepository.Verify(
            repo => repo.UpdateAsync(
                It.Is<IndividualClient>(
                    c => 
                        c.Address == "New Test Address" && 
                        c.Email == "newTest@email.com" &&
                        c.PhoneNumber == "987654321" &&
                        c.FirstName == "New Test First Name" &&
                        c.LastName == "New Test Last Name")
            ), Times.Once);
    }

    [Fact]
    public async Task TestIndividualClientDeleted()
    {

        // Arrange
        var client = new IndividualClient()
        {
            IdClient = 1,
            Address = "Test Address",
            Email = "test@email.com",
            PhoneNumber = "123456789",
            FirstName = "Test First Name",
            LastName = "Test Last Name",
            Pesel = "12345678901"
        };
        _mockRepository.Setup(x => x.FindAsync(1)).ReturnsAsync(client);
        
        // Act
        await _clientService.DeleteIndividualClient(1);

        _mockRepository.Verify(x => x.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task TestDeletedIndividualClientUpdate()
    {

        // Arrange
        var client = new IndividualClient()
        {
            IdClient = 1,
            Address = "Test Address",
            Email = "test@email.com",
            PhoneNumber = "123456789",
            FirstName = "Test First Name",
            LastName = "Test Last Name",
            Pesel = "12345678901",
            IsDeleted = true
        };
        _mockRepository.Setup(x => x.FindAsync(1)).ReturnsAsync(client);

        // Act & Assert
        await Assert.ThrowsAsync<DeletedClientException>(() => _clientService.UpdateIndividualClient(1,
            new UpdateIndividualClientDto()
            {
                Address = "New Test Address"
            }));
    }
}