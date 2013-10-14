// Set an off-center projection, where perspective's vanishing
	// point is not necessarily in the center of the screen.
	//
	// leftrighttop/bottom define near plane size, i.e.
	// how offset are corners of camera's near plane.
	// Tweak the values and you can see camera's frustum change.
	@script ExecuteInEditMode
	var left : float = -0.2;
	var right : float = 0.2;
	var top : float = 0.2;
	var bottom : float = -0.2;
	function LateUpdate () {
		var cam : Camera = camera;
		var m : Matrix4x4 = PerspectiveOffCenter(
			left, right, bottom, top,
			cam.nearClipPlane, cam.farClipPlane );
		cam.projectionMatrix = m;
	}
	static function PerspectiveOffCenter(
		left : float, right : float,
		bottom : float, top : float,
		near : float, far : float ) : Matrix4x4
	{        
		var x : float =  (2.0 * near) / (right - left);
		var y : float =  (2.0 * near) / (top - bottom);
		var a : float =  (right + left) / (right - left);
		var b : float =  (top + bottom) / (top - bottom);
		var c : float = -(far + near) / (far - near);
		var d : float = -(2.0 * far * near) / (far - near);
		var e : float = -1.0;
		var m : Matrix4x4 = new Matrix4x4();
		m[0,0] = x;  m[0,1] = 0;  m[0,2] = a;  m[0,3] = 0;
		m[1,0] = 0;  m[1,1] = y;  m[1,2] = b;  m[1,3] = 0;
		m[2,0] = 0;  m[2,1] = 0;  m[2,2] = c;  m[2,3] = d;
		m[3,0] = 0;  m[3,1] = 0;  m[3,2] = e;  m[3,3] = 0;
		return m;
	}