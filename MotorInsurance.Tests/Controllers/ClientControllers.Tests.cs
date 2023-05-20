using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using motorInsurance.Controllers;
using MotorInsurance.Models;
using MotorInsurance.Services.Clients;
using MotorInsurance.Services.Exceptions;
using Xunit;

namespace MotorInsurance.Tests;

public class ClientControllers
{
    private Mock<IClientsService> _clientsServiceMock;

    private void Setup()
    {
        this._clientsServiceMock = new Mock<IClientsService>();
    }

    public ClientControllers()
    {
        this.Setup();
    }

    [Fact]
    public async Task ClientController_GetAll_Should()
    {
        var clientList = GetClientsData();
        _clientsServiceMock.Setup(x => x.GetAll())
        .ReturnsAsync(clientList);

        var clientController = new ClientController(_clientsServiceMock.Object);

        var clientResult = await clientController.GetAll() as OkObjectResult;

        Assert.NotNull(clientResult);
        Assert.True(clientList.Equals(clientResult.Value));
    }

    [Fact]
    public async Task ClientController_GetById_Should()
    {
        var id = "646ae202515208cf1491114f";
        var clientsList = GetClientsData();
        _clientsServiceMock.Setup(x => x.GetById(id))
        .ReturnsAsync(() => clientsList.Find((client) => client.ClientID == id));

        var clientController = new ClientController(_clientsServiceMock.Object);

        var clientResult = await clientController.GetById(id) as OkObjectResult;

        Assert.NotNull(clientResult);
        Assert.True(clientsList.Contains((Client) clientResult.Value));
    }

    [Fact]
    public void ClientController_GetById_ThrowsNotExistenException()
    {
        var id = "646ae202515208cf1491113f";
        var clientsList = GetClientsData();
        _clientsServiceMock.Setup(x => x.GetById(id))
        .ReturnsAsync(() => clientsList.Find((client) => client.ClientID == id));

        var clientController = new ClientController(_clientsServiceMock.Object);

        Assert.ThrowsAsync<NotExistentException>(() => clientController.GetById(id));
    }

    private List<Client> GetClientsData()
    {
        List<Client> clientsData = new List<Client>
        {
            new Client
            {
                ClientID = "646ae202515208cf1491114f",
                Name = "Karol Vanessa Leiton",
                BirthDate = new DateTime(1980, 2, 13),
                City = "Medellin",
                Address = "Provenza"
            },
            new Client
            {
                ClientID = "646ae202515208cf1491115f",
                Name = "Manuel Felipe Figueroa",
                BirthDate = new DateTime(1973, 8, 15),
                City = "Tulua",
                Address = "Calle 30"
            },
        };
        return clientsData;
    }
}