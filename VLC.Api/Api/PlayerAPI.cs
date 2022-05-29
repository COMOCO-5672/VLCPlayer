using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VLC.Api.Api
{
    public class PlayerAPI
    {
        #region libvlc_media.h

        /// <summary>
        /// 使用一个给定的媒体资源路径来建立一个(libvlc_media实例)
        /// </summary>
        /// <param name="libvlc">(libvlc实例)</param>
        /// <param name="psz_mrl">要读取的MRL(Media Resource Location)</param>
        /// <returns>(libvlc_media实例)或NULL</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_new_location(IntPtr libvlc, [MarshalAs(UnmanagedType.LPArray)] byte[] psz_mrl);

        /// <summary>
        /// 从本地文件系统路径来建立一个(libvlc_media实例)
        /// </summary>
        /// <param name="libvlc">(libvlc实例)</param>
        /// <param name="psz_mrl">要读取的MRL(Media Resource Location)</param>
        /// <returns>(libvlc_media实例)或NULL</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_new_path(IntPtr libvlc, [MarshalAs(UnmanagedType.LPArray)] byte[] psz_mrl);

        /// <summary>
        /// 使用给定的名称创建一个libvlc_media_t并将其作为一个空的节点
        /// </summary>
        /// <param name="libvlc">(libvlc实例)</param>
        /// <param name="psz_name"></param>
        /// <returns>(libvlc_media实例)或NULL</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_new_as_node(IntPtr libvlc, [MarshalAs(UnmanagedType.LPArray)] byte[] psz_name);

        /// <summary>
        /// 此选项将用于确定media_player如何读取媒体。这允许在每个媒体的基础上使用VLC的高级读/流选项。这些选项在vlc -long-help中有详细说明，
        /// 例如“--sout-all”。请注意，所有选项在媒体上都不可用：具体而言，由于体系结构问题，无法在单个媒体上设置视频相关选项（如文本渲染器选项）
        /// 。必须在整个libvlc实例上设置它们。
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        /// <param name="psz_options ">选项（作为字符串）</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_add_option(IntPtr libvlc_media, [MarshalAs(UnmanagedType.LPArray)] byte[] psz_options);

        /// <summary>
        /// 此选项将用于确定media_player如何读取媒体。这允许在每个媒体的基础上使用VLC的高级读/流选项。这些选项在vlc -long-help中有详细说明，
        /// 例如“--sout-all”。请注意，所有选项在媒体上都不可用：具体而言，由于体系结构问题，无法在单个媒体上设置视频相关选项（如文本渲染器选项）
        /// 。必须在整个libvlc实例上设置它们。
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        /// <param name="psz_options">选项（作为字符串）</param>
        /// <param name="i_flags">此选项的标志</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_add_option_flag(IntPtr libvlc_media, [MarshalAs(UnmanagedType.LPArray)] byte[] psz_options, int i_flags);

        /// <summary>
        /// 保留一个引用到一个媒体描述对象(libvlc_media_t.使用libvlc_media_release()来减少一个媒体描述对象的引用计数
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_retain(IntPtr libvlc_media);

        /// <summary>
        /// 减少一个libvlc_media_t的引用计数,如果引用计数为0，则libvlc_media_release（）将释放媒体描述符对象。它将向所有侦听器发送libvlc_MediaFreed事件
        /// 。如果已释放媒体描述符对象，则不应再次使用它
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_release(IntPtr libvlc_media);

        /// <summary>
        /// 从媒体描述符对象获取媒体资源定位符（mrl）
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        /// <returns></returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.AnsiBStr)]
        public static extern string libvlc_media_get_mrl(IntPtr libvlc_media);

        /// <summary>
        /// 复制媒体描述符对象。
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        /// <returns></returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_duplicate(IntPtr libvlc_media);

        ///// <summary>
        ///// 获取媒体的元数据。如果媒体还没被解析，则返回NULL，这个方法会自动调用
        ///// </summary>
        ///// <param name="libvlc_media">(libvlc_media实例)</param>
        ///// <param name="e_meta">要阅读的元数据</param>
        ///// <returns>媒体的元数据</returns>
        //[DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        //public static extern IntPtr libvlc_media_get_meta(IntPtr libvlc_media, libvlc_meta_t e_meta);

        ///// <summary>
        ///// 设置媒体的元数据,此方法不会保存数据,还需要调用libvlc_media_save_meta()来保存.
        ///// </summary>
        ///// <param name="libvlc_media">(libvlc_media实例)</param>
        ///// <param name="e_meta">要设置的元数据</param>
        ///// <param name="psz_value"></param>
        //[DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void libvlc_media_set_meta(IntPtr libvlc_media, libvlc_meta_t e_meta, [MarshalAs(UnmanagedType.LPArray)] byte[] psz_value);

        /// <summary>
        /// 保存以前设置的元数据
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        /// <returns>如果写操作成功，则为true</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_save_meta(IntPtr libvlc_media);

        ///// <summary>
        ///// 获取媒体描述符对象的当前状态。可能的媒体状态是libvlc_NothingSpecial = 0，libvlc_Opening，libvlc_Playing，libvlc_Paused，libvlc_Stopped，
        ///// libvlc_Ended，libvlc_Error
        ///// </summary>
        ///// <param name="libvlc_media">(libvlc_media实例)</param>
        ///// <returns></returns>
        //[DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        //public static extern libvlc_state_t libvlc_media_get_state(IntPtr libvlc_media);

        ///// <summary>
        ///// 获取有关媒体的最新统计信息。
        ///// </summary>
        ///// <param name="libvlc_media">(libvlc_media实例)</param>
        ///// <param name="p_stats">包含媒体统计信息的结构（此结构必须由调用者分配）</param>
        ///// <returns>如果统计信息可用，则为true，否则为false</returns>
        //[DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int libvlc_media_get_stats(IntPtr libvlc_media, out libvlc_media_stats_t p_stats);

        /// <summary>
        /// 获取媒体描述符对象的子项。这将增加提供的媒体描述符对象的引用计数。使用libvlc_media_list_release（）减少引用计数。
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        /// <returns>媒体描述符子项列表或NULL</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_subitems(IntPtr libvlc_media);

        /// <summary>
        /// 获得一个媒体描述对象的事件管理器.
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        /// <returns></returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_event_manager(IntPtr libvlc_media);

        /// <summary>
        /// 获取媒体描述符对象项的持续时间（以毫秒为单位）
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        /// <returns>媒体项的持续时间或错误的-1</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int64 libvlc_media_get_duration(IntPtr libvlc_media);

        /// <summary>
        /// 解析一个本地媒体的元数据和轨道信息,此方法是同步的.
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_parse(IntPtr libvlc_media);

        /// <summary>
        /// 同上,此方法不同步,你可以监听libvlc_MediaParsedChanged事件来追踪他，如果已经被解析过了则此事件不会被触发。
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_parse_async(IntPtr libvlc_media);

        /// <summary>
        /// 获得一个媒体描述对象的分析状态。
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        /// <returns>当分析过了返回true</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool libvlc_media_is_parsed(IntPtr libvlc_media);

        /// <summary>
        /// 获取媒体描述符的用户数据,此数据仅被host程序访问,VLC.framework将它作为一个指向一个引用了一个libvlc_media_t指针的本地对象的指针来使用
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        /// <returns></returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_get_user_data(IntPtr libvlc_media);

        /// <summary>
        /// 设置媒体描述符的用户数据,此数据仅被host程序访问,VLC.framework将它作为一个指向一个引用了一个libvlc_media_t指针的本地对象的指针来使用
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        /// <param name="p_new_user_data"></param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_set_user_data(IntPtr libvlc_media, IntPtr p_new_user_data);

        /// <summary>
        /// 获取媒体描述符的基本流描述。 注意，在调用此函数之前，您需要至少调用一次libvlc_media_parse（）或播放媒体。不这样做会导致数组为空。
        /// </summary>
        /// <param name="libvlc_media">(libvlc_media实例)</param>
        /// <param name="tracks">用于存储已分配的基本流描述数组的地址（必须由调用者释放）[OUT]</param>
        /// <returns></returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_get_tracks_info(IntPtr libvlc_media, out IntPtr tracks);

        #endregion
    }
}
