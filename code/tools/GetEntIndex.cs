namespace Sandbox.Tools
{
	[Library( "tool_getentindex", Title = "Get Entity IDs", Description = "Prints the network ID and hammer ID of the target entity." )]
	public partial class GetEntIndexTool : BaseTool
	{
		public override void Simulate()
		{
			if ( !Host.IsServer ) return;

			using ( Prediction.Off() )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack ) )
				{
					TraceResult tr = DoTrace();
					if ( tr.Hit && tr.Entity.IsValid() )
					{
						Log.Info( tr.Entity.NetworkIdent );
					}
				}
				else if ( Input.Pressed( InputButton.SecondaryAttack ) )
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
}
