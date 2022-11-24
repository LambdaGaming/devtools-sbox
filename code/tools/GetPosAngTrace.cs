namespace Sandbox.Tools
{
	[Library( "tool_getposangtrace", Title = "Get Trace Pos and Angle", Description = "Prints position and angles of target entity." )]
	public partial class GetPosAngTraceTool : BaseTool
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
						Log.Info( tr.Entity.Position );
					}
				}
				else if ( Input.Pressed( InputButton.SecondaryAttack ) )
				{
					TraceResult tr = DoTrace();
					if ( tr.Hit && tr.Entity.IsValid() )
					{
						Log.Info( tr.Entity.Rotation.Angles() );
					}
				}
			}
		}
	}
}
