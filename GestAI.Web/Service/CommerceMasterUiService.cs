namespace GestAI.Web.Service;

public sealed class CommerceMasterUiService
{
    public string SaveMessage(string entityLabel, bool isCreate)
        => isCreate
            ? $"{entityLabel} creado correctamente."
            : $"{entityLabel} actualizado correctamente.";

    public string ToggleMessage(string entityLabel, bool wasActive)
        => wasActive
            ? $"{entityLabel} desactivado."
            : $"{entityLabel} activado.";
}
