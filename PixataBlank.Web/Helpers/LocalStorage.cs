using System.Text.Json;
using Microsoft.JSInterop;

namespace PixataBlank.Web.Helpers;

public class LocalStorage {
  protected IJSRuntime JsRuntimeInstance { get; set; }

  public LocalStorage(IJSRuntime jsRuntime) =>
    JsRuntimeInstance = jsRuntime;

  public ValueTask SetItem(string key, object data) =>
    JsRuntimeInstance.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(data));

  public async Task<T> GetItem<T>(string key) {
    string data = await JsRuntimeInstance.InvokeAsync<string>("localStorage.getItem", key);
    return !string.IsNullOrEmpty(data) ? JsonSerializer.Deserialize<T>(data) : default;
  }

  public ValueTask RemoveItem(string key) =>
    JsRuntimeInstance.InvokeVoidAsync("localStorage.removeItem", key);
}