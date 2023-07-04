using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using PrintDocument.Core;
using PrintDocument.Core.Entities;
using PrintDocument.Core.Exception;
using PrintDocumentBlazor.Shared.Dialogs;

namespace PrintDocumentBlazor.Pages;

partial class Home
{
    [Inject]
    public PrintContext context { get; set; } = default!;

    [Inject]
    private ISnackbar Snackbar { get; set; } = default!;

    [Inject]
    public IDialogService DialogService { get; set; } = default!;


    private HashSet<CategoryReport> categories = new HashSet<CategoryReport>();

    public string plainText = string.Empty;

    private Dictionary<string, object> editorConf = new Dictionary<string, object>
{
    {"height", 750}
};

    private IOrderedEnumerable<IGrouping<char, Document>> GroupedDocuments = default!;

    protected override async Task OnInitializedAsync()
    {
        await GetCategories();
        await GetDocuments();
    }

    //ریشه جدید در درخت ایجاد میکند
    private async Task OpenAddRootDialog()
    {
        try
        {
            DialogOptions options = new DialogOptions() { CloseOnEscapeKey = false, DisableBackdropClick = true };
            DialogParameters parametrs = new DialogParameters
        {
            { "IsEdit", false },
            { "SubmitButtonColor", Color.Success },
            { "SubmitButtonText", "ثبت" }
        };
            var addDialog = DialogService.Show<AddEditCategoryBranchDialog>("افزودن موضوع اصلی", parametrs, options);
            var result = await addDialog.Result;
            if (!result.Canceled)
            {
                await GetCategories();
            }
        }
        catch (AppException ax)
        {
            Snackbar.Add(ax.Message, Severity.Warning);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }

    //شاخه به ریشه درخت اضافه میکند
    private async Task OpenAddBranchDialog(int parentId)
    {
        try
        {
            DialogOptions options = new DialogOptions() { CloseOnEscapeKey = false, DisableBackdropClick = true };
            DialogParameters parametrs = new DialogParameters
        {
            { "IsEdit", false },
            { "IsRoot", false },
            { "ParentId", parentId },
            { "SubmitButtonColor", Color.Success },
            { "SubmitButtonText", "ثبت" }
        };
            var addDialog = DialogService.Show<AddEditCategoryBranchDialog>("افزودن موضوع فرعی", parametrs, options);
            var result = await addDialog.Result;
            if (!result.Canceled)
            {
                await GetCategories();
            }
        }
        catch (AppException ax)
        {
            Snackbar.Add(ax.Message, Severity.Warning);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    //مدال برای تغییر شاخه
    private async Task OpenEditBranchDialog(CategoryReport branch)
    {
        try
        {
            DialogOptions options = new DialogOptions() { CloseOnEscapeKey = false, DisableBackdropClick = true };
            DialogParameters parametrs = new DialogParameters
        {
            { "IsEdit", true },
            { "IsRoot", false },
            { "BranchId", branch.Id },
            { "ParentId", branch.ParentId },
            { "Branch", branch },
            { "SubmitButtonColor", Color.Info },
            { "SubmitButtonText", "ثبت تغییرات" }
        };
            var addDialog = DialogService.Show<AddEditCategoryBranchDialog>("ویرایش موضوع", parametrs, options);
            var result = await addDialog.Result;
            if (!result.Canceled)
            {
                await GetCategories();
            }
        }
        catch (AppException ax)
        {
            Snackbar.Add(ax.Message, Severity.Warning);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }

    //شاخه را حذف میکند
    private async Task OpenDeleteBranchDialog(CategoryReport selectedBranch)
    {
        try
        {
            DialogOptions options = new DialogOptions() { CloseOnEscapeKey = true };
            DialogParameters parmeters = new DialogParameters
        {
            { "ContentText", $"آیا از حذف {selectedBranch.Name} انتخابی اطمینان دارید " },
            { "ButtonText", "حذف" },
            { "Color", Color.Error }
        };
            var dialodDelete = DialogService.Show<MessageDialog>("", parmeters, options);
            var result = await dialodDelete.Result;
            if (!result.Canceled)
            {
                var category = await context.Categories.FirstOrDefaultAsync(i => i.Id == selectedBranch.Id);

                if (category == null) throw new AppException("کد موضوع مورد نظر یافت نشد");

                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                Snackbar.Add("عملیات حذف با موفقیت انجام شد", Severity.Success);
                await GetCategories();
            }
        }
        catch (AppException ax)
        {
            Snackbar.Add(ax.Message, Severity.Warning);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }

    private async Task OpenDocumentsDialog(int id)
    {
        try
        {
            DialogOptions options = new DialogOptions() { CloseButton = true };
            DialogParameters parmeters = new DialogParameters
        {
            { "CategoryId", id },
        };
            var dialodDelete = DialogService.Show<CategoryRelatedDocumentsDialog>("", parmeters, options);
            var result = await dialodDelete.Result;
            if (!result.Canceled)
            {
                var docId = Convert.ToInt32(result.Data);
                var document = await GetDocumentById(docId);
                plainText = document.PlainText;
                StateHasChanged();
            }
        }
        catch (AppException ax)
        {
            Snackbar.Add(ax.Message, Severity.Warning);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }

    private async Task OpenSaveDocumentDialog()
    {
        try
        {
            DialogOptions options = new DialogOptions() { CloseOnEscapeKey = false, DisableBackdropClick = true };
            DialogParameters parametrs = new DialogParameters
        {
            { "IsEdit", false },
            { "SubmitButtonColor", Color.Success },
            { "SubmitButtonText", "ذخیره" },
            {"Document" , new Document { PlainText = plainText } }
        };
            var addDialog = DialogService.Show<AddEditDocumentDialog>("ذخیره سند", parametrs, options);
            var result = await addDialog.Result;
            if (!result.Canceled)
            {
                await GetCategories();
                await GetDocuments();
            }
        }
        catch (AppException ax)
        {
            Snackbar.Add(ax.Message, Severity.Warning);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }

    private async Task OpenNewDocument()
    {
        if (string.IsNullOrEmpty(plainText) is not true)
        {
            DialogOptions options = new DialogOptions() { CloseOnEscapeKey = true };
            DialogParameters parmeters = new DialogParameters
        {
            { "ContentText", $"در صورت ایجاد سند جدید سند قبلی حذف خواهد شد آیا از ایجاد سند جدید اطمینان دارید؟" },
            { "ButtonText", "بله" },
            { "Color", Color.Warning }
        };
            var dialodDelete = DialogService.Show<MessageDialog>("", parmeters, options);
            var result = await dialodDelete.Result;
            if (result.Canceled is not true)
                plainText = string.Empty;
        }
    }

    private async Task<Document> GetDocumentById(int docId)
    {
        var document = await context.Documents.FirstOrDefaultAsync(i => i.Id == docId);
        if (document == null) throw new AppException("سند مورد نظر یافت نشد");
        return document;
    }

    private async Task GetCategories()
    {
        var result = await context.Categories.AsNoTracking()
            .Where(i => i.ParentId == null)
            .Include(i => i.Documents)
            .Include(i => i.ChildCategories)
            .ToListAsync();
        categories = await FillList(result);
    }

    private async Task GetDocuments()
    {
        try
        {
            var documents = await context.Documents.AsNoTracking().ToListAsync();
            GroupedDocuments = documents.GroupBy(d => d.Title[0]).OrderBy(g => g.Key);
        }
        catch (AppException ax)
        {
            Snackbar.Add(ax.Message, Severity.Warning);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }

    private async Task<HashSet<CategoryReport>> FillList(List<Category> listIn)
    {
        HashSet<CategoryReport> list = new HashSet<CategoryReport>();
        foreach (var item in listIn)
        {
            var init = await context.Categories.AsNoTracking().Where(i => i.ParentId == item.Id)
                .Include(i => i.ChildCategories)
                .Include(i => i.Documents)
                .ToListAsync();
            var re = new CategoryReport
            {
                Id = item.Id,
                Name = item.Name,
                ParentId = item.ParentId,
                Documents = item.Documents,
                CategoryChildren = await FillList(init),
            };
            list.Add(re);
        }
        return list;
    }


}
