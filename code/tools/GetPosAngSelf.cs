namespace Sandbox.Tools
{
	[Library( "tool_getposangself", Title = "Get Self Pos and Angle", Description = "Prints position and eye angles of yourself." )]
	public partial class GetPosAngSelfTool : BaseTool
	{
		public override void Simulate()
		{
			if ( !Host.IsServer ) return;

			using ( Prediction.Off() )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack ) )
					Log.Info( Owner.Position );
				else if ( Input.Pressed( InputButton.SecondaryAttack ) )
					Log.Info( Owner.EyeRotation.Angles() );
			}
		}
	}
}
