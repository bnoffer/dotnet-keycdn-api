using System;
using System.Threading.Tasks;
using Refit;
using Com.KeyCDN.Api.Schemas;

namespace Com.KeyCDN.Api.Interfaces
{
	public interface IZonealiases
	{
		[Get("/zonealiases.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> List([Header("Authorization")] string authorization);

		[Post("/zonealiases.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> Add([Header("Authorization")] string authorization,
													     [Body] Zonealias body);

		[Put("/zonealiases/{zonealias_id}.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> Edit([Header("Authorization")] string authorization,
														  [AliasAs("zonealias_id")] int id,
														  [Body] Zonealias body);

		[Delete("/zonealiases/{zonealias_id}.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> Delete([Header("Authorization")] string authorization,
														    [AliasAs("zonealias_id")] int id);
	}
}

