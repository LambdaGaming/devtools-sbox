using System.Collections.Generic;
using System.Linq;

namespace Sandbox.Tools;

[Library( "tool_findentity", Title = "Find Entity", Description = "Prints velocity and angular velocity of target entity." )]
public partial class FindEntityTool : BaseTool
{
	int Index = 0;
	static List<Entity> EntList = new();

	public override void Simulate()
	{
		if ( !Game.IsServer ) return;

		using ( Prediction.Off() )
		{
			if ( Input.Pressed( "attack1" ) )
				TeleTo( true );
			else if ( Input.Pressed( "attack2" ) )
				TeleTo( false );
		}
	}

	void TeleTo( bool forward )
	{
		if ( EntList.Count <= 0 )
		{
			Log.Warning( "Use the devtools_findent command to enter an entity name." );
			return;
		}

		if ( forward )
			Index = ( int ) MathX.Clamp( Index + 1, 0, EntList.Count - 1 );
		else
			Index = ( int ) MathX.Clamp( Index - 1, 0, EntList.Count - 1 );

		if ( EntList[Index].IsValid() )
		{
			Owner.Position = EntList[Index].Position;
			Log.Info( $"Current Entity: {Index + 1} out of {EntList.Count}" );
		}
		else
		{
			EntList.Remove( EntList[Index] );
			Log.Warning( $"The selected entity doesn't exist anymore. Removing from list." );
		}
	}

	// This will be set through a UI eventually
	[ConCmd.Server( "devtools_findent" )]
	static void FindEntity( string parameter )
	{
		EntList.Clear();
		EntList.AddRange( Entity.All.Where( x => ( x.ClassName == parameter) ) );
		if ( EntList.Count > 0 )
			Log.Info( $"Found {EntList.Count} entities with the specified class name on the map." );
		else
			Log.Info( $"No entities with the class name '{parameter}' could be found on the map." );
	}
}
