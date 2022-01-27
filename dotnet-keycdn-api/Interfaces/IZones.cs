using System;
using System.Threading.Tasks;
using Refit;
using Com.KeyCDN.Api.Schemas;

namespace Com.KeyCDN.Api.Interfaces
{
	public interface IZones
	{
		[Get("/zones.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> List([Header("Authorization")] string authorization);

		[Get("/zones/{zone_id}.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> View([Header("Authorization")] string authorization,
													      [AliasAs("zone_id")] int id);

		[Post("/zones.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> Add([Header("Authorization")] string authorization,
													     [Body] Zone body);

		[Put("/zones/{zone_id}.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> Edit([Header("Authorization")] string authorization,
														  [AliasAs("zone_id")] int id,
														  [Body] Zone body);

		[Delete("/zones/{zone_id}.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> Delete([Header("Authorization")] string authorization,
														    [AliasAs("zone_id")] int id);

		[Get("/zones/purge/{zone_id}.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> PurgeCache([Header("Authorization")] string authorization,
														        [AliasAs("zone_id")] int id);

		[Delete("/zones/purgeurl/{zone_id}.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> PurgeUrl([Header("Authorization")] string authorization,
														      [AliasAs("zone_id")] int id);

		[Delete("/zones/purgeurl/{zone_id}.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> PurgeUrls([Header("Authorization")] string authorization,
														       [AliasAs("zone_id")] int id,
															   [Body] PurgeUrlsBody body);
	}
}

