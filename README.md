# arcgis-rest-dotnet
.Net rest api wrapper library for consuming arcgis rest api.

## v0.1b Currently supports
* Authentication
* Geometry Service (Project Polygons, Calculate Areas and Length)
* Feature Layer Service (Can query feature layers)

**Cross platform because of .Net Standard 2.0. Please collaborate to make this into a complete rest client for ArcGIS RestAPI**

## Sample Code

```csharp
    // Authentication
    var authService = new F4GISAuthService(host, username, password);
    // Get Auth Token
    var authTokenResp = await authService.GetToken();

    
    // Geometry Service
    var geometryService = new F4GISGeometryService(host);
    // Project Polygons to diffrent spatial reference
    PolygonGeometry projected = await geometryService.ProjectPolygon(authToken, inSR, outSR, originalGeometry);
    // Calculate Areas and Length
    F4GISAreaLengthResponse areaLenth = await geometryService.CalculateAreasAndLengths(authToken, SR,
                            EsriGeometryCalcType.preserveShape, EsriAreaUnit.esriAcres, projected);

```