namespace Sandbox.Tools
{
	[Library( "tool_getposangself", Title = "Get Self Pos and Angle", Description = "Prints position and eye angles of yourself." )]
	public partial class GetPosAngSelfTool : BaseTool
	{
		public override void Simulate()
		{
			if ( !Game.IsServer ) return;

			using ( Prediction.Off() )
			{
				if ( Input.Pressed( "attack1" ) )
					Log.Info( Owner.Position );
				else if ( Input.Pressed( "attack2" ) )
					Log.Info( Owner.EyeRotation.Angles() );
			}
		}
	}
}
