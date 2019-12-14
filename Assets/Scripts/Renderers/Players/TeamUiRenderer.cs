using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Team))]
[RequireComponent(typeof(TeamControllerBase))]
public class TeamUiRenderer : RendererBase
{
    public Team team { get; private set; }
    public TeamControllerBase controller { get; set; }
    [field: SerializeField]
    public Text balanceText { get; set; }


    [field: SerializeField]
    public GameObject buyItemParent { get; set; }

    [field: SerializeField]
    public Button buyItemElementPrefab { get; set; }

    private IDictionary<MenuItemAsset, Button> menuItemAssets = new Dictionary<MenuItemAsset, Button>();

    private void Awake()
    {
        team = GetComponent<Team>();
        controller = GetComponent<TeamControllerBase>();
    }

    private void Start()
    {
        foreach (var item in team.teamAsset.buyables)
        {
            var @object = Instantiate(buyItemElementPrefab, buyItemParent.transform);
            var button = @object.GetComponent<Button>();
            button.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
            {
                Debug.Log($"Trying to buy {item.displayName}...");
                controller.Buy(item);
            }));

            menuItemAssets.Add(item, @object);
        }
    }

    private void Update()
    {
        balanceText.text = $"{team.bankAccount.balance}$";
    }

    public void DisplayPrompt(string message, Color color)
    {

    }
}
