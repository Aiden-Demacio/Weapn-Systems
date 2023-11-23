using UnityEngine;

public static class InputManager
{
    private static Controls _ctrls;

    private static Vector3 _mousePos;

    private static Vector3 MovDir;

    private static Vector3 RotDir;

    private static Camera cam;
    public static Ray GetCameraRay()
    {
        return cam.ScreenPointToRay(_mousePos);
    }

    public static void Init(PlayerControls p) 
    {
        _ctrls = new();

        cam = Camera.main;

        _ctrls.Permenanet.Enable();

        _ctrls.InGame.Shoot.performed += _ =>
        {
            p.Shoot();
        };
        _ctrls.Permenanet.MousePos.performed += ctx =>
        {
            _mousePos = ctx.ReadValue<Vector2>();
        };

        _ctrls.InGame.Movement.performed += ctx =>
        {

            MovDir = ctx.ReadValue<Vector3>();
            p.SetMovDir(MovDir);
            p.setState(PlayerControls.EPlayerMovementState.Moving);
        };
        _ctrls.InGame.Rotation.performed += ctx =>
        {

            RotDir = ctx.ReadValue<Vector3>();
            p.SetRotDir(RotDir);
        };
        _ctrls.InGame.WeaponSwitch.performed += ctx =>
        {

            p.switchWeapon();
        };
        _ctrls.InGame.Reload.performed += ctx =>
        {

            p.reload();
            
        };
        _ctrls.InGame.Jump.performed += ctx =>
        {

            p.SetJump();
            p.setState(PlayerControls.EPlayerMovementState.Jumping);
        };
        
    }

    

    public static void EnableInGame()
    {
        _ctrls.InGame.Enable();
    }
}
