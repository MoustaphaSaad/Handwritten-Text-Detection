/*
 * MATLAB Compiler: 6.1 (R2015b)
 * Date: Wed Dec 09 18:18:11 2015
 * Arguments: "-B" "macro_default" "-W" "lib:MAsset" "-T" "link:lib" "-d"
 * "H:\Projects\Handwritten-Text-Detection\Handwritten-Text-Detection\Operations
 * \MAsset\for_testing" "-v"
 * "H:\Projects\Handwritten-Text-Detection\Handwritten-Text-Detection\Operations
 * \ConnectedComponent.m"
 * "H:\Projects\Handwritten-Text-Detection\Handwritten-Text-Detection\Operations
 * \IncreaseContrast.m" 
 */

#ifndef __MAsset_h
#define __MAsset_h 1

#if defined(__cplusplus) && !defined(mclmcrrt_h) && defined(__linux__)
#  pragma implementation "mclmcrrt.h"
#endif
#include "mclmcrrt.h"
#ifdef __cplusplus
extern "C" {
#endif

#if defined(__SUNPRO_CC)
/* Solaris shared libraries use __global, rather than mapfiles
 * to define the API exported from a shared library. __global is
 * only necessary when building the library -- files including
 * this header file to use the library do not need the __global
 * declaration; hence the EXPORTING_<library> logic.
 */

#ifdef EXPORTING_MAsset
#define PUBLIC_MAsset_C_API __global
#else
#define PUBLIC_MAsset_C_API /* No import statement needed. */
#endif

#define LIB_MAsset_C_API PUBLIC_MAsset_C_API

#elif defined(_HPUX_SOURCE)

#ifdef EXPORTING_MAsset
#define PUBLIC_MAsset_C_API __declspec(dllexport)
#else
#define PUBLIC_MAsset_C_API __declspec(dllimport)
#endif

#define LIB_MAsset_C_API PUBLIC_MAsset_C_API


#else

#define LIB_MAsset_C_API

#endif

/* This symbol is defined in shared libraries. Define it here
 * (to nothing) in case this isn't a shared library. 
 */
#ifndef LIB_MAsset_C_API 
#define LIB_MAsset_C_API /* No special import/export declaration */
#endif

extern LIB_MAsset_C_API 
bool MW_CALL_CONV MAssetInitializeWithHandlers(
       mclOutputHandlerFcn error_handler, 
       mclOutputHandlerFcn print_handler);

extern LIB_MAsset_C_API 
bool MW_CALL_CONV MAssetInitialize(void);

extern LIB_MAsset_C_API 
void MW_CALL_CONV MAssetTerminate(void);



extern LIB_MAsset_C_API 
void MW_CALL_CONV MAssetPrintStackTrace(void);

extern LIB_MAsset_C_API 
bool MW_CALL_CONV mlxConnectedComponent(int nlhs, mxArray *plhs[], int nrhs, mxArray 
                                        *prhs[]);

extern LIB_MAsset_C_API 
bool MW_CALL_CONV mlxIncreaseContrast(int nlhs, mxArray *plhs[], int nrhs, mxArray 
                                      *prhs[]);



extern LIB_MAsset_C_API bool MW_CALL_CONV mlfConnectedComponent(int nargout, mxArray** output, mxArray* img);

extern LIB_MAsset_C_API bool MW_CALL_CONV mlfIncreaseContrast(int nargout, mxArray** result, mxArray* img);

#ifdef __cplusplus
}
#endif
#endif
