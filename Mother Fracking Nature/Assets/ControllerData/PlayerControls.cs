//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/ControllerData/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerActions"",
            ""id"": ""c62a0f12-352d-4199-8c46-863b3313dbe8"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c541585a-a3e6-4b01-9c55-e6a195a1d1de"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""075eeee0-f0cb-40b8-9b05-023f15f78e04"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""StartGame"",
                    ""type"": ""Button"",
                    ""id"": ""02fe800e-e9e0-4b8d-99dc-a058af28842f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuitGame"",
                    ""type"": ""Button"",
                    ""id"": ""38046006-0e00-4c62-aabc-399b55438310"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Revive"",
                    ""type"": ""Button"",
                    ""id"": ""290ea849-a42f-4f0e-bca2-f90c997b3480"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Join"",
                    ""type"": ""Button"",
                    ""id"": ""479457ea-d4b2-44af-8628-ba73d6fce510"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3be790e0-e08e-41fb-befb-cec3f036db45"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1eab5bda-586c-46d8-954a-c765dd59886a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""306a6c90-2ed9-4480-bb64-b5f2722fbbbe"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c9476a5-7e9f-477d-ae3e-a35794d1fcbd"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuitGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c83ac13d-6680-4502-9c97-ee0afd37c7cd"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Revive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1120b01-8f61-4f84-8273-a888c98f754f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""DefenderActions"",
            ""id"": ""09e6a52f-6f58-4000-8671-58a0c9859f4a"",
            ""actions"": [
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""9d870c0c-116d-496e-a9be-c8867d0d5493"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Trap"",
                    ""type"": ""Button"",
                    ""id"": ""cf5cdd1a-d6df-4632-8f80-e8a23f3f6af3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftScroll"",
                    ""type"": ""Button"",
                    ""id"": ""a7846b6a-fba0-46c9-b019-9cd4a9d2dca8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightScroll"",
                    ""type"": ""Button"",
                    ""id"": ""2d5b03af-1a88-4769-8b6d-2e21535a5d63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Repair"",
                    ""type"": ""Value"",
                    ""id"": ""1d999ac5-9b5e-4ed5-9b78-c16120aebdc7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3f993701-db0c-40da-b66f-a517c35cc381"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b4b9dda-2bcd-48ee-a940-51b206e032a0"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4a98ded-fdbe-4a4a-b261-d45d9c85b6df"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bae111e-3e14-48f8-a9cd-18f596875d9b"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45397c05-6e81-40fb-b48e-0945a04d3e94"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Repair"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""AttackerActions"",
            ""id"": ""70d127af-c55e-4110-854e-a7fdbe42d8e2"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""8a62cd0b-92ad-4c96-9139-cb3d50705cf5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""93946c32-fead-4e38-8381-a56a1fdfbd85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftScroll"",
                    ""type"": ""Button"",
                    ""id"": ""e007460f-319b-46b3-8796-bce480e1a345"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightScroll"",
                    ""type"": ""Button"",
                    ""id"": ""6a7ac222-4514-418b-b0a6-d847c7653796"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8fc3d22e-445e-4f98-9d95-ede6ba0c4c26"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71ec8978-c96d-4cb2-a4b0-4f8f39507600"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fe90a18-5f7c-410b-a8b0-c8c820753284"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a173dc00-e9cc-4745-a190-db5057384c51"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerActions
        m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
        m_PlayerActions_Move = m_PlayerActions.FindAction("Move", throwIfNotFound: true);
        m_PlayerActions_Rotate = m_PlayerActions.FindAction("Rotate", throwIfNotFound: true);
        m_PlayerActions_StartGame = m_PlayerActions.FindAction("StartGame", throwIfNotFound: true);
        m_PlayerActions_QuitGame = m_PlayerActions.FindAction("QuitGame", throwIfNotFound: true);
        m_PlayerActions_Revive = m_PlayerActions.FindAction("Revive", throwIfNotFound: true);
        m_PlayerActions_Join = m_PlayerActions.FindAction("Join", throwIfNotFound: true);
        // DefenderActions
        m_DefenderActions = asset.FindActionMap("DefenderActions", throwIfNotFound: true);
        m_DefenderActions_Block = m_DefenderActions.FindAction("Block", throwIfNotFound: true);
        m_DefenderActions_Trap = m_DefenderActions.FindAction("Trap", throwIfNotFound: true);
        m_DefenderActions_LeftScroll = m_DefenderActions.FindAction("LeftScroll", throwIfNotFound: true);
        m_DefenderActions_RightScroll = m_DefenderActions.FindAction("RightScroll", throwIfNotFound: true);
        m_DefenderActions_Repair = m_DefenderActions.FindAction("Repair", throwIfNotFound: true);
        // AttackerActions
        m_AttackerActions = asset.FindActionMap("AttackerActions", throwIfNotFound: true);
        m_AttackerActions_Attack = m_AttackerActions.FindAction("Attack", throwIfNotFound: true);
        m_AttackerActions_Ability = m_AttackerActions.FindAction("Ability", throwIfNotFound: true);
        m_AttackerActions_LeftScroll = m_AttackerActions.FindAction("LeftScroll", throwIfNotFound: true);
        m_AttackerActions_RightScroll = m_AttackerActions.FindAction("RightScroll", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerActions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_Move;
    private readonly InputAction m_PlayerActions_Rotate;
    private readonly InputAction m_PlayerActions_StartGame;
    private readonly InputAction m_PlayerActions_QuitGame;
    private readonly InputAction m_PlayerActions_Revive;
    private readonly InputAction m_PlayerActions_Join;
    public struct PlayerActionsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerActions_Move;
        public InputAction @Rotate => m_Wrapper.m_PlayerActions_Rotate;
        public InputAction @StartGame => m_Wrapper.m_PlayerActions_StartGame;
        public InputAction @QuitGame => m_Wrapper.m_PlayerActions_QuitGame;
        public InputAction @Revive => m_Wrapper.m_PlayerActions_Revive;
        public InputAction @Join => m_Wrapper.m_PlayerActions_Join;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRotate;
                @StartGame.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnStartGame;
                @StartGame.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnStartGame;
                @StartGame.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnStartGame;
                @QuitGame.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnQuitGame;
                @QuitGame.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnQuitGame;
                @QuitGame.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnQuitGame;
                @Revive.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRevive;
                @Revive.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRevive;
                @Revive.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRevive;
                @Join.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJoin;
                @Join.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJoin;
                @Join.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJoin;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @StartGame.started += instance.OnStartGame;
                @StartGame.performed += instance.OnStartGame;
                @StartGame.canceled += instance.OnStartGame;
                @QuitGame.started += instance.OnQuitGame;
                @QuitGame.performed += instance.OnQuitGame;
                @QuitGame.canceled += instance.OnQuitGame;
                @Revive.started += instance.OnRevive;
                @Revive.performed += instance.OnRevive;
                @Revive.canceled += instance.OnRevive;
                @Join.started += instance.OnJoin;
                @Join.performed += instance.OnJoin;
                @Join.canceled += instance.OnJoin;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

    // DefenderActions
    private readonly InputActionMap m_DefenderActions;
    private IDefenderActionsActions m_DefenderActionsActionsCallbackInterface;
    private readonly InputAction m_DefenderActions_Block;
    private readonly InputAction m_DefenderActions_Trap;
    private readonly InputAction m_DefenderActions_LeftScroll;
    private readonly InputAction m_DefenderActions_RightScroll;
    private readonly InputAction m_DefenderActions_Repair;
    public struct DefenderActionsActions
    {
        private @PlayerControls m_Wrapper;
        public DefenderActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Block => m_Wrapper.m_DefenderActions_Block;
        public InputAction @Trap => m_Wrapper.m_DefenderActions_Trap;
        public InputAction @LeftScroll => m_Wrapper.m_DefenderActions_LeftScroll;
        public InputAction @RightScroll => m_Wrapper.m_DefenderActions_RightScroll;
        public InputAction @Repair => m_Wrapper.m_DefenderActions_Repair;
        public InputActionMap Get() { return m_Wrapper.m_DefenderActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefenderActionsActions set) { return set.Get(); }
        public void SetCallbacks(IDefenderActionsActions instance)
        {
            if (m_Wrapper.m_DefenderActionsActionsCallbackInterface != null)
            {
                @Block.started -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnBlock;
                @Block.performed -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnBlock;
                @Block.canceled -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnBlock;
                @Trap.started -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnTrap;
                @Trap.performed -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnTrap;
                @Trap.canceled -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnTrap;
                @LeftScroll.started -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnLeftScroll;
                @LeftScroll.performed -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnLeftScroll;
                @LeftScroll.canceled -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnLeftScroll;
                @RightScroll.started -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnRightScroll;
                @RightScroll.performed -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnRightScroll;
                @RightScroll.canceled -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnRightScroll;
                @Repair.started -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnRepair;
                @Repair.performed -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnRepair;
                @Repair.canceled -= m_Wrapper.m_DefenderActionsActionsCallbackInterface.OnRepair;
            }
            m_Wrapper.m_DefenderActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
                @Trap.started += instance.OnTrap;
                @Trap.performed += instance.OnTrap;
                @Trap.canceled += instance.OnTrap;
                @LeftScroll.started += instance.OnLeftScroll;
                @LeftScroll.performed += instance.OnLeftScroll;
                @LeftScroll.canceled += instance.OnLeftScroll;
                @RightScroll.started += instance.OnRightScroll;
                @RightScroll.performed += instance.OnRightScroll;
                @RightScroll.canceled += instance.OnRightScroll;
                @Repair.started += instance.OnRepair;
                @Repair.performed += instance.OnRepair;
                @Repair.canceled += instance.OnRepair;
            }
        }
    }
    public DefenderActionsActions @DefenderActions => new DefenderActionsActions(this);

    // AttackerActions
    private readonly InputActionMap m_AttackerActions;
    private IAttackerActionsActions m_AttackerActionsActionsCallbackInterface;
    private readonly InputAction m_AttackerActions_Attack;
    private readonly InputAction m_AttackerActions_Ability;
    private readonly InputAction m_AttackerActions_LeftScroll;
    private readonly InputAction m_AttackerActions_RightScroll;
    public struct AttackerActionsActions
    {
        private @PlayerControls m_Wrapper;
        public AttackerActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_AttackerActions_Attack;
        public InputAction @Ability => m_Wrapper.m_AttackerActions_Ability;
        public InputAction @LeftScroll => m_Wrapper.m_AttackerActions_LeftScroll;
        public InputAction @RightScroll => m_Wrapper.m_AttackerActions_RightScroll;
        public InputActionMap Get() { return m_Wrapper.m_AttackerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AttackerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IAttackerActionsActions instance)
        {
            if (m_Wrapper.m_AttackerActionsActionsCallbackInterface != null)
            {
                @Attack.started -= m_Wrapper.m_AttackerActionsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_AttackerActionsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_AttackerActionsActionsCallbackInterface.OnAttack;
                @Ability.started -= m_Wrapper.m_AttackerActionsActionsCallbackInterface.OnAbility;
                @Ability.performed -= m_Wrapper.m_AttackerActionsActionsCallbackInterface.OnAbility;
                @Ability.canceled -= m_Wrapper.m_AttackerActionsActionsCallbackInterface.OnAbility;
                @LeftScroll.started -= m_Wrapper.m_AttackerActionsActionsCallbackInterface.OnLeftScroll;
                @LeftScroll.performed -= m_Wrapper.m_AttackerActionsActionsCallbackInterface.OnLeftScroll;
                @LeftScroll.canceled -= m_Wrapper.m_AttackerActionsActionsCallbackInterface.OnLeftScroll;
                @RightScroll.started -= m_Wrapper.m_AttackerActionsActionsCallbackInterface.OnRightScroll;
                @RightScroll.performed -= m_Wrapper.m_AttackerActionsActionsCallbackInterface.OnRightScroll;
                @RightScroll.canceled -= m_Wrapper.m_AttackerActionsActionsCallbackInterface.OnRightScroll;
            }
            m_Wrapper.m_AttackerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Ability.started += instance.OnAbility;
                @Ability.performed += instance.OnAbility;
                @Ability.canceled += instance.OnAbility;
                @LeftScroll.started += instance.OnLeftScroll;
                @LeftScroll.performed += instance.OnLeftScroll;
                @LeftScroll.canceled += instance.OnLeftScroll;
                @RightScroll.started += instance.OnRightScroll;
                @RightScroll.performed += instance.OnRightScroll;
                @RightScroll.canceled += instance.OnRightScroll;
            }
        }
    }
    public AttackerActionsActions @AttackerActions => new AttackerActionsActions(this);
    public interface IPlayerActionsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnStartGame(InputAction.CallbackContext context);
        void OnQuitGame(InputAction.CallbackContext context);
        void OnRevive(InputAction.CallbackContext context);
        void OnJoin(InputAction.CallbackContext context);
    }
    public interface IDefenderActionsActions
    {
        void OnBlock(InputAction.CallbackContext context);
        void OnTrap(InputAction.CallbackContext context);
        void OnLeftScroll(InputAction.CallbackContext context);
        void OnRightScroll(InputAction.CallbackContext context);
        void OnRepair(InputAction.CallbackContext context);
    }
    public interface IAttackerActionsActions
    {
        void OnAttack(InputAction.CallbackContext context);
        void OnAbility(InputAction.CallbackContext context);
        void OnLeftScroll(InputAction.CallbackContext context);
        void OnRightScroll(InputAction.CallbackContext context);
    }
}
