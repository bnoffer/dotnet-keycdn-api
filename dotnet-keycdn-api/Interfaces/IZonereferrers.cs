using System;
using System.Threading.Tasks;
using Refit;
using Com.KeyCDN.Api.Schemas;

namespace Com.KeyCDN.Api.Interfaces
{
	public interface IZonereferrers
	{
		[Get("/zonereferrers.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> List([Header("Authorization")] string authorization);

		[Post("/zonereferrers.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> Add([Header("Authorization")] string authorization,
													     [Body] Zonealias body);

		[Put("/zonereferrers/{zonereferrer_id}.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> Edit([Header("Authorization")] string authorization,
													      [AliasAs("zonereferrer_id")] int id,
												    	  [Body] Zonealias body);

		[Delete("/zonereferrers/{zonereferrer_id}.json")]
		Task<Refit.ApiResponse<Schemas.ApiResponse>> Delete([Header("Authorization")] string authorization,
													 	   [AliasAs("zonereferrer_id")] int id);
	}
}

