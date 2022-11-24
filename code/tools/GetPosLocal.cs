namespace Sandbox.Tools
{
	[Library( "tool_getposlocal", Title = "Get Pos Relative To Trace Entity", Description = "Prints position and angles of target entity." )]
	public partial class GetPosLocalTool : BaseTool
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
						Log.Info( tr.Entity.Transform.PointToLocal( tr.HitPosition ) );
					}
				}
			}
		}
	}
}
