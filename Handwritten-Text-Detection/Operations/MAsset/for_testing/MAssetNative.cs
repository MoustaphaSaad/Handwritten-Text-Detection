/*
* MATLAB Compiler: 6.1 (R2015b)
* Date: Wed Dec 09 21:01:53 2015
* Arguments: "-B" "macro_default" "-W" "dotnet:MAsset,MAsset,0.0,private" "-T" "link:lib"
* "-d"
* "H:\Projects\Handwritten-Text-Detection\Handwritten-Text-Detection\Operations\MAsset\for
* _testing" "-v"
* "class{MAsset:H:\Projects\Handwritten-Text-Detection\Handwritten-Text-Detection\Operatio
* ns\ConnectedComponent.m,H:\Projects\Handwritten-Text-Detection\Handwritten-Text-Detectio
* n\Operations\IncreaseContrast.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace MAssetNative
{

  /// <summary>
  /// The MAsset class provides a CLS compliant, Object (native) interface to the MATLAB
  /// functions contained in the files:
  /// <newpara></newpara>
  /// H:\Projects\Handwritten-Text-Detection\Handwritten-Text-Detection\Operations\Connect
  /// edComponent.m
  /// <newpara></newpara>
  /// H:\Projects\Handwritten-Text-Detection\Handwritten-Text-Detection\Operations\Increas
  /// eContrast.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class MAsset : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Runtime instance.
    /// </summary>
    static MAsset()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

          int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "MAsset.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the MAsset class.
    /// </summary>
    public MAsset()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~MAsset()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the ConnectedComponent
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object ConnectedComponent()
    {
      return mcr.EvaluateFunction("ConnectedComponent", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the ConnectedComponent
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="img">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object ConnectedComponent(Object img)
    {
      return mcr.EvaluateFunction("ConnectedComponent", img);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the ConnectedComponent MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] ConnectedComponent(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "ConnectedComponent", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the ConnectedComponent MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="img">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] ConnectedComponent(int numArgsOut, Object img)
    {
      return mcr.EvaluateFunction(numArgsOut, "ConnectedComponent", img);
    }


    /// <summary>
    /// Provides an interface for the ConnectedComponent function in which the input and
    /// output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("ConnectedComponent", 1, 1, 0)]
    protected void ConnectedComponent(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("ConnectedComponent", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the IncreaseContrast MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object IncreaseContrast()
    {
      return mcr.EvaluateFunction("IncreaseContrast", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the IncreaseContrast MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="img">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object IncreaseContrast(Object img)
    {
      return mcr.EvaluateFunction("IncreaseContrast", img);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the IncreaseContrast MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] IncreaseContrast(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "IncreaseContrast", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the IncreaseContrast MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="img">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] IncreaseContrast(int numArgsOut, Object img)
    {
      return mcr.EvaluateFunction(numArgsOut, "IncreaseContrast", img);
    }


    /// <summary>
    /// Provides an interface for the IncreaseContrast function in which the input and
    /// output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("IncreaseContrast", 1, 1, 0)]
    protected void IncreaseContrast(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("IncreaseContrast", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }

    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
