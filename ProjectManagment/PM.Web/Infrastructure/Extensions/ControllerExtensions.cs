using System.IO;
using System.Web.Mvc;

namespace PM.Web.Infrastructure
{
    /// <summary>
    /// Controller extensions class.
    /// </summary>
    public static class ControllerExtensions
    {
        /// <summary>
        /// Renders the specific view.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="model">The view model.</param>
        /// <param name="viewData">The view data.</param>
        /// <returns>Rendered HTML string for specified view.</returns>
        public static string RenderView(this Controller controller, string viewName, object model, ViewDataDictionary viewData = null)
        {
            var viewModelData = new ViewDataDictionary(model);

            if (viewData != null)
            {
                foreach (var entry in viewData)
                    viewModelData.Add(entry.Key, entry.Value);
            }

            return RenderView(controller, viewName, viewModelData);
        }

        /// <summary>
        /// Renders the specific view.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="viewData">The view data.</param>
        /// <returns>Rendered HTML string for specified view.</returns>
        public static string RenderView(this Controller controller, string viewName, ViewDataDictionary viewData)
        {
            var controllerContext = controller.ControllerContext;
            var viewResult = ViewEngines.Engines.FindView(controllerContext, viewName, null);
            StringWriter stringWriter;

            using (stringWriter = new StringWriter())
            {
                var viewContext = new ViewContext(
                    controllerContext,
                    viewResult.View,
                    viewData,
                    controllerContext.Controller.TempData,
                    stringWriter);

                viewResult.View.Render(viewContext, stringWriter);
                viewResult.ViewEngine.ReleaseView(controllerContext, viewResult.View);
            }

            return stringWriter.ToString();
        }
    }
}
