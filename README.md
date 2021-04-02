# .NET wrapper for  Molog WMS Open API
This is .NET sample for Molog WMS Open API

# Usage

1. Require `MologOpenAPI` class

    ```
	using MologWMSOpenApi;
    ```

2. Instantiate a MologOpenApiClient Object

    ```
    var client = new MologWMSOpenApiClient(appKey, appSecret);
    ```

3. Create token for set access token

    ```
    // Create Token API
	
    await client.CreateToken(username, password);
  
    // If Access Token is expired, you can use refresh token
    await client.RefreshToken();
    ```

4. Call API action with proper parameters  

    ```
	var inventoryList = await client.Inventory.Get(new Dictionary<string, object> {
        { "PAGE", 1 },
        { "SIZE", 10 },
        { "RECEIVED_DATE_FROM", "2021-03-23T00:00:00+07:00" },
        { "RECEIVED_DATE_TO", "2021-03-23T23:59:59+07:00" },
    });
    ```
5. For available API actions, check the [offcial documentation](https://app.mologtech.com/open-api-doc-th/)

# API Support

| Advance Shipment Notice        | Status             |
| ------------------------------ | ------------------ |
| Create ASN Job                 | :heavy_check_mark: |

---

| Confirm Packed                 | Status             |
| ------------------------------ | ------------------ |
| Select Confirm Packed by Job   | :heavy_check_mark: |

---

| Confirm Picked                 | Status             |
| ------------------------------ | ------------------ |
| Select Confirm Picked by Job   | :heavy_check_mark: |

---

| Confirm Shipped                 | Status             |
| ------------------------------ | ------------------ |
| Select Confirm Shipped by Job   | :heavy_check_mark: |

---

| Crosscheck                     | Status             |
| ------------------------------ | ------------------ |
| Select summary of ASN          | :heavy_check_mark: |
| Select summary of DSO          | :heavy_check_mark: |

---

| Direct Shipment Order          | Status             |
| ------------------------------ | ------------------ |
| Create DSO Job                 | :heavy_check_mark: |
| Update Consignee and ShipTo    | :heavy_check_mark: |
| Update Invoice                 | :heavy_check_mark: |
| Cancel DSO                     | :heavy_check_mark: |

---

| Goods Receive                  | Status             |
| ------------------------------ | ------------------ |
| Select Goods Receive ฺby Job    | :heavy_check_mark: |

---

| Inventory                      | Status             |
| ------------------------------ | ------------------ |
| Select inventory list          | :heavy_check_mark: |

---

| Partner                        | Status             |
| ------------------------------ | ------------------ |
| Create or Update Partner       | :heavy_check_mark: |

---

| Pre Shipment Order             | Status             |
| ------------------------------ | ------------------ |
| Create PSO Job                 | :heavy_check_mark: |

---

| SKU                            | Status             |
| ------------------------------ | ------------------ |
| Create or Update SKU           | :heavy_check_mark: |
| Update SKU Bom                 | :heavy_check_mark: |

---

| System                         | Status             |
| ------------------------------ | ------------------ |
| Create token                   | :heavy_check_mark: |
| Delete Token                   | :heavy_check_mark: |
| Refresh token                  | :heavy_check_mark: |

---

# Development

## Tools

- .NET Core - runtime
- Visual Studio 2019 - recommended text editor

# Reference
## MOLOG - OPEN API Offcial Documentation
https://app.mologtech.com/open-api-doc-th/