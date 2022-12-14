namespace Sandbox.Tools
{
	[Library( "tool_getvelocity", Title = "Get Velocity", Description = "Prints velocity and angular velocity of target entity." )]
	public partial class GetVelocityTool : BaseTool
	{
		public override void Simulate()
		{
			if ( !Game.IsServer ) return;

			using ( Prediction.Off() )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack ) )
				{
					TraceResult tr = DoTrace();
					if ( tr.Hit && tr.Entity.IsValid() )
					{
						Log.Info( tr.Entity.Velocity );
					}
				}
				else if ( Input.Pressed( InputButton.SecondaryAttack ) )
				{
					TraceResult tr = DoTrace();
					if ( tr.Hit && tr.Entity.IsValid() )
					{
						Log.Info( tr.Entity.AngularVelocity );
					}
				}
			}
		}
	}
}
