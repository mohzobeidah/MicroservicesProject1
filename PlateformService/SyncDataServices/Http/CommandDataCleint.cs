using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PlateformService.Dtos;

namespace PlateformService.SyncDataServices.Http
{
    public class CommandDataCleint : ICommandDataCleint
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CommandDataCleint(HttpClient httpClient , IConfiguration configuration)
        {
            this._configuration = configuration;
            this._httpClient = httpClient;

        }
        public async Task SendPlateformToCommand(PlateformReadDtos plateformReadDtos)
        {
            var httpContent = new StringContent(
             JsonSerializer.Serialize(plateformReadDtos),
             Encoding.UTF8, 
             "application/json"
            );
            var response = await _httpClient.PostAsync($"{_configuration["commandServiceUrl"]}", httpContent);

            if (response.IsSuccessStatusCode)
                Console.WriteLine("send was ok ");

            Console.WriteLine("send was not ok ");

        }
    }
}
