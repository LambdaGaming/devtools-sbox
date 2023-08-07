namespace Sandbox.Tools;

[Library( "tool_getentindex", Title = "Get Entity IDs", Description = "Prints the network ID and hammer ID of the target entity." )]
public partial class GetEntIndexTool : BaseTool
{
	public override void Simulate()
	{
		if ( !Game.IsServer ) return;

		using ( Prediction.Off() )
		{
			if ( Input.Pressed( "attack1" ) )
			{
				TraceResult tr = DoTrace();
				if ( tr.Hit && tr.Entity.IsValid() )
				{
					Log.Info( tr.Entity.NetworkIdent );
				}
			}
			else if ( Input.Pressed( "attack2" ) )
			{
				TraceResult tr = DoTrace();
				if ( tr.Hit && tr.Entity.IsValid() )
				{
					Log.Info( tr.Entity.HammerID );
				}
			}
		}
	}
}
